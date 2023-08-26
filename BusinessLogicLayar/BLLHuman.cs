using System;
using DataAccessLayer;
using Business_Entity;

namespace BusinessLogicLayer

{
    public class BLLHuman
    {
        public void Create (Human human)
        {
            DALHuman dALHuman = new DALHuman();
            dALHuman.Create (human);
        }
        public List<Human> Read()
        {
            DALHuman dALHuman = new DALHuman();
            return dALHuman.Read();

        }
        public List<Human> Search(List<string> tags)
        {
            DALHuman dALHuman = new DALHuman();
            return dALHuman.Search(tags);

        }
    }
}