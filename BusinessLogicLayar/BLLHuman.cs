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
    }
}