using EditorColonThree.UI;
using Zenject;

namespace EditorColonThree.Installers
{
    class MenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UI.Menu>().FromNewComponentOnRoot().AsSingle();
        }
    }
}
