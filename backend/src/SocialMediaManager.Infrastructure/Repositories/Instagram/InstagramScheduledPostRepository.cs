using Microsoft.EntityFrameworkCore;
using SocialMediaManager.Domain.Models.Instagram;
using SocialMediaManager.Infrastructure.Database;
using SocialMediaManager.Infrastructure.Repositories.Interfaces;
using SocialMediaManager.Infrastructure.Repositories.Interfaces.Instagram;

namespace SocialMediaManager.Infrastructure.Repositories.Instagram;

public class InstagramScheduledPostRepository(AppDbContext dbContext) : IInstagramScheduledPostRepository
{
    
    private readonly AppDbContext _dbContext = dbContext;
    private readonly DbSet<InstagramScheduledPost> _dbSet = dbContext.Set<InstagramScheduledPost>();
    
    public async Task Add(InstagramScheduledPost post)
    {
       await _dbSet.AddAsync(post);
       await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<InstagramScheduledPost>> GetScheduledPosts()
    {
        var posts = await _dbSet.ToListAsync();
        return posts;
    }

    public Task<InstagramScheduledPost> GetScheduledPost(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(InstagramScheduledPost post)
    {
        throw new NotImplementedException();
    }

    public async Task SetAsPublished(InstagramScheduledPost post)
    {
        var postToUpdate = await _dbSet.FindAsync(post.Id);

        if (postToUpdate is not null)
        {
            postToUpdate.IsPublished = true;
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<InstagramScheduledPost?> GetScheduledPostByCreationId(string id)
    {
        var post = await _dbSet.FirstOrDefaultAsync(x => x.CreationId == id);
        return post;
    }

    public Task Delete(InstagramScheduledPost post)
    {
        throw new NotImplementedException();
    }
}