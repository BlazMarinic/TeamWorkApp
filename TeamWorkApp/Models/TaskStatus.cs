using System.ComponentModel.DataAnnotations;

namespace TeamWorkApp.Models
{
    public enum TaskStatus
    {
        [Display(Name = "Novo")]
        New,
        [Display(Name = "V teku")]
        InProgress,
        [Display(Name = "Zaključeno")]
        Completed
    }
}