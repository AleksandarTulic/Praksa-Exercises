using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyRepository.PostgreSQL{
    public class Repository<T> : DbSet<T>, IRepository<T> where T : Entity{

        public DbContext Context {get; set;}
        public DbSet<T> Rows {get; set;}

        public Repository(){
        }

        public Repository(DbContext context){
            this.Context = context;
        }

        public override IEntityType EntityType => Rows.EntityType;

        public async Task CreateAsync(T entity){
            if (entity == null){
                throw new ArgumentNullException(nameof(entity));
            }

            await Rows.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id){
            //Entity obj = new Entity() { Id = id };

            //Rows.Remove(obj);
            await Rows.Where(e => e.Id == id).ExecuteDeleteAsync();
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(){
            return await Rows.ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Func<T, bool> filter){
            var result = Rows.Where(filter);

            return await result.AsQueryable().ToListAsync();
        }

        public async Task<T> GetAsync(Guid id){
            return await Rows.FindAsync(id);
        }

        public async Task<T> GetAsync(Func<T, bool> filter){
            return await Rows.FindAsync(filter);
        }

        public async Task UpdateAsync(T entity){
            if (entity == null){
                throw new ArgumentNullException(nameof(entity));
            }

            Rows.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}