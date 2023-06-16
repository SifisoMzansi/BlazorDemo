using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class PeopleData : IPeopleData
    {
        private readonly ISqlDataAccess _sqlDataAccess;


        public PeopleData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from [User] ";
            return _sqlDataAccess.LoadData<PersonModel, dynamic>(sql, new { });
        }
        public Task InsertPerson(PersonModel person)
        {
            string sql = " INSERT INTO [User] values (@FirstName , @lastName, @EmailAddress, null ) ";
            return _sqlDataAccess.SaveData(sql, person);
        }
    }
}
