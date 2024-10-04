
using Microsoft.EntityFrameworkCore;

public class PersonRepository(PersonDbContext personDbContext) : IPersonRepository
{
    public async Task<bool> CreatePersonAsync(Person person)
    {
        try
        {
            personDbContext.People.Add(person);
            int res = await personDbContext.SaveChangesAsync();
            return res != 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeletePersonAsync(int id)
    {
        try
        {
            Person? person = await personDbContext.People.FindAsync(id);
            if (person == null) return false;
            personDbContext.People.Remove(person);
            int res = await personDbContext.SaveChangesAsync();
            return res > 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<Person?> GetPersonById(int id)
    {
        try
        {
            return await personDbContext.People.FindAsync(id);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return new Person();
        }
    }

    public async Task<IEnumerable<Person>> GetUsersAsync()
    {
        try
        {
            return await personDbContext.People.ToListAsync();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Person>();
        }
    }

    public async Task<bool> UpdatePersonAsync(Person person)
    {
        try
        {
            Person? person1 = await personDbContext.People.FindAsync(person.Id);
            if (person1 == null)
            {
                return false;
            }
            // personDbContext.People.Update(person);
            person1.Name=person.Name;
            person1.Email=person.Email;
            person1.Address=person.Address;
            
            int res = await personDbContext.SaveChangesAsync();
            return res>0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }
}