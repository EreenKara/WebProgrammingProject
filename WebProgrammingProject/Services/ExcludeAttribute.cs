using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingProject.Services
{
    public class ExcludeAttribute:BindAttribute  // Biraz fazlaya kaciyor gibi oldum o yüzden saldım
    {

        string[] exclusives;
        string[] temporaryInclude;

        public ExcludeAttribute(string yazi)
        {
            
            //Include.CopyTo(temporaryInclude,0);
            exclusives=yazi.Split(',');
            foreach (var item in Include)
            {
                
                if(exclusives.Contains(item))
                {

                }
            }
        }
        
        
    }
}
