using HelpYou.Component.Interface.Model;

namespace HelpYou.Component.Interface.Web
{
    public interface ICustom:IHelpYou<CustomModel>
    {
        int Add(CustomModel model);
        CustomModel Query(string loginId);
        bool IsExists(CustomModel model);
    }
}
