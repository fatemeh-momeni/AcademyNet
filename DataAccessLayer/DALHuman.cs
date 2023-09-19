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
        public void Update(Human humans)
        {
            DB db = new DB();
            var q = from i in db.Human where i.Id == humans.Id select i;
            Human human =new Human();
             human = q.Single();
            human.Id = humans.Id;
            human.Name = humans.Name;
            human.Family = humans.Family;
            human.Picture = humans.Picture;
            human.Password = humans.Password;
            human.Email = humans.Email;
            human.gender = humans.gender;
            human.role = humans.role;

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