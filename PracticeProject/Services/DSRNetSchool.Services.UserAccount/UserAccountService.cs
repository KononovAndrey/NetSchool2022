namespace DSRNetSchool.Services.UserAccount;

using AutoMapper;
using DSRNetSchool.Common.Exceptions;
using DSRNetSchool.Common.Validator;
using DSRNetSchool.Context.Entities;
using DSRNetSchool.Services.Actions;
using DSRNetSchool.Services.EmailSender;
using DSRNetSchool.Services.UserAccount;
using Microsoft.AspNetCore.Identity;

public class UserAccountService : IUserAccountService
{
    private readonly IMapper mapper;
    private readonly UserManager<User> userManager;
    private readonly IAction action;
    private readonly IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator;

    public UserAccountService(
        IMapper mapper, 
        UserManager<User> userManager, 
        IAction action,
        IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator)
    {
        this.mapper = mapper;
        this.userManager = userManager;
        this.action = action;
        this.registerUserAccountModelValidator = registerUserAccountModelValidator;
    }

    public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
    {
        registerUserAccountModelValidator.Check(model);

        // Find user by email
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null)
            throw new ProcessException($"User account with email {model.Email} already exist.");

        // Create user account
        user = new User()
        {
            Status = UserStatus.Active,
            FullName = model.Name,
            UserName = model.Email,  // Это логин. Мы будем его приравнивать к email, хотя это и не обязательно
            Email = model.Email,
            EmailConfirmed = true, // Так как это учебный проект, то сразу считаем, что почта подтверждена. В реальном проекте, скорее всего, надо будет ее подтвердить через ссылку в письме
            PhoneNumber = null,
            PhoneNumberConfirmed = false
            // ... Также здесь есть еще интересные свойства. Посмотрите в документации.
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {String.Join(", ", result.Errors.Select(s => s.Description))}");


        await action.SendEmail(new EmailModel
        {
            Email = model.Email,
            Subject = "DSRNetSchool notification",
            Message = "You are registered"
        });


        // Returning the created user
        return mapper.Map<UserAccountModel>(user);
    }
}
