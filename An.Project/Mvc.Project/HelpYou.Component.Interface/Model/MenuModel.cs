using System.ComponentModel.DataAnnotations.Schema;

namespace HelpYou.Component.Interface.Model
{
    [Table("Sys_Menu")]
    public class MenuModel:BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ParentUrl { get; set; }
        public int Level { get; set; }
    }
}
