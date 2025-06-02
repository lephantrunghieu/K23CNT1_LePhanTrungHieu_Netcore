using System.ComponentModel.DataAnnotations;

namespace LpthLesson07.Models
{
    public class LpthMember
    {
        public int LpthId { get; set; }

        public string LpthName { get; set; }
        public string LpthUserName { get; set; }

        public string LpthPassword { get; set; }

        public string LpthEmail { get; set; }

        public bool LpthStatus { get; set; }
    }
}
