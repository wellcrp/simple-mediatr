using Simple.Mediatr.Model.People;
using Simple.Mediatr.Repository.Interface.People;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Mediatr.Repository.Repository.People
{
    public class PeopleRepository : IPeopleRepository<PeopleModel>
    {
        private static Dictionary<int, PeopleModel> peopleList = new Dictionary<int, PeopleModel>();

        public async Task Add(PeopleModel people) => await Task.Run(() => peopleList.Add(people.PeopleId, people));
        public async Task Delete(int id) => await Task.Run(() => peopleList.Remove(id));
        public async Task<IEnumerable<PeopleModel>> GetAll() => await Task.Run(() => peopleList.Values.ToList());
        public async Task<PeopleModel> GetById(int id) => await Task.Run(() => peopleList.FirstOrDefault(x => x.Value.PeopleId.Equals(id)).Value);
        public async Task Edit(PeopleModel people)
        {
            await Task.Run(() =>
            {
                peopleList.Remove(people.PeopleId);
                peopleList.Add(people.PeopleId, people);
            });
        }
    }
}
