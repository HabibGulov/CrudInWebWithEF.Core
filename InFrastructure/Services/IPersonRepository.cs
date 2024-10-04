public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetUsersAsync();
    Task<Person?> GetPersonById(int id);
    Task<bool> CreatePersonAsync(Person person);    
    Task<bool> UpdatePersonAsync(Person person);
    Task<bool> DeletePersonAsync(int id);
}