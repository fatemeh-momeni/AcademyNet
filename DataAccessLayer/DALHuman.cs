using Business_Entity;
namespace DataAccessLayer
{
    public class DALHuman
    {
        public void Create(Human humans)
        {
            DB db = new DB();
            db.Human.Add(humans);
            db.SaveChanges();
        }
        public List<Human> Read()
        {
            DB db = new DB();
            return db.Human.ToList();

        }
        public List<Human> Search(List<string> tags)
        {
            List<Human> humanList = new List<Human>();
            foreach (string item in tags)
            {
                DB db = new DB();
                var query = from i in db.Human
                            where i.Name.Contains(item.ToString()) || i.Family.Contains(item.ToString()) || i.Email.Contains(item.ToString())
                            select i;
                humanList = humanList.Concat(query.ToList()).ToList();

            }
            return humanList;
        }

    }
}