using System.Collections.Generic;
using DPcode.Core.IModel;

namespace DPcode.Core.Model
{
    public class Menu : IMenu
    {
        public Menu(string _descriptor){
            this._descriptor=_descriptor;
        }
        private List<IMenu> branches = new List<IMenu>();
        private IMenu super; 
        private string _descriptor;
        public bool AddBranch(IMenu menu)
        {
            branches.Add(menu);
            return branches.Contains(menu);
        }

        public List<IMenu> GetBraches()
        {
            return branches;
        }

        public string GetDescriptor()
        {
            return this._descriptor;
        }

        public IMenu GetSuper()
        {
            return super;
        }

        public bool SetBranches(List<IMenu> branchMenus)
        {
            this.branches=branchMenus;
            return this.branches==branchMenus;
        }

        public string SetDescriptor(string _descriptor)
        {
            this._descriptor=_descriptor;
            return _descriptor;
        }

        public bool SetSuper(IMenu menu)
        {
            this.super=menu;
            return super==menu;
        }
    }
}