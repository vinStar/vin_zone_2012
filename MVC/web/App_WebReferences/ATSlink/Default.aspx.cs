using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ATSlink_Default : System.Web.UI.Page
{
    com.monster.schemas.MonsterBusinessGatewayService monsterService = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        PostingInventory();
    }


    void GetAuthentication()
    {


        monsterService = new com.monster.schemas.MonsterBusinessGatewayService();
        com.monster.schemas.MonsterHeader monsterHeader = new com.monster.schemas.MonsterHeader();
        com.monster.schemas.MessageDataType messageDateType = new com.monster.schemas.MessageDataType();
        messageDateType.MessageId = Guid.NewGuid().ToString();
        messageDateType.Timestamp = DateTime.Now.ToString();
        monsterHeader.MessageData = messageDateType;
        monsterService.MonsterHeaderValue = monsterHeader;
        com.monster.schemas.Security1 security = new com.monster.schemas.Security1();
        com.monster.schemas.UsernameTokenType1 userNameTokenType = new com.monster.schemas.UsernameTokenType1();
        com.monster.schemas.PasswordType1 passwordType = new com.monster.schemas.PasswordType1();
        passwordType.Value = "fkr304306";// YourPassWord;
        userNameTokenType.Username = "pamelaice";// YourUserName;
        userNameTokenType.Password = passwordType;
        security.UsernameToken = userNameTokenType;
        monsterService.Security = security;
    }


    void PostingInventory()
    {
        GetAuthentication();

        com.monster.schemas.InventoriesQueryType inventoriesQueryType = new com.monster.schemas.InventoriesQueryType(); // new BGWAPP.com.monster.schemas.InventoriesQueryType();
        com.monster.schemas.LicenseFilterEnumStr licenseFileter = new com.monster.schemas.LicenseFilterEnumStr();// new BGWAPP.com.monster.schemas.LicenseFilterEnumStr();
        licenseFileter.monsterId = com.monster.schemas.LicenseFilterIdEnum.Item2;
        inventoriesQueryType.LicenseFilter = licenseFileter;
        com.monster.schemas.LicenseTypeEnumStr licenseType = new com.monster.schemas.LicenseTypeEnumStr();//k new BGWAPP.com.monster.schemas.LicenseTypeEnumStr();
        licenseType.monsterId = com.monster.schemas.LicenseTypeIdEnum.Item1;
        inventoriesQueryType.LicenseType = licenseType;


        com.monster.schemas.InventoriesQueryResponseType res = monsterService.InventoriesQuery(inventoriesQueryType);
        


    }


}