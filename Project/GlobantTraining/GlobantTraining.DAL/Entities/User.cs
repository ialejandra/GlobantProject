

namespace GlobantTraining.DAL.Entities
{
    public class User
    {
        
        public int Id { get; set; }

        public string DocumentNumber { get; set; }


        public int TypeUserId { get; set; }
        public virtual TypeUser TypeUser { get; set; }


        public string Title { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }
    }
}
