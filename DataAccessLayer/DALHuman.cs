using Business_Entity;
namespace DataAccessLayer
{
    public class DALHuman
    {
        public void Create(Human humans)
        {
            DB db = new DB();
            db.humans.Add(humans);
            db.SaveChanges();
        }

    }
}