namespace DSRNetSchool.Services.Authors;

using AutoMapper;
using DSRNetSchool.Context;
using Microsoft.EntityFrameworkCore;

public class AuthorService : IAuthorService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public AuthorService(
        IDbContextFactory<MainDbContext> contextFactory, 
        IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<AuthorModel>> GetAuthors()
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Authors = context
            .Authors
            .AsQueryable();

        var data = (await Authors.ToListAsync()).Select(Author => mapper.Map<AuthorModel>(Author));

        return data;
    }
}
