﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using beans;
using NHibernate;

public partial class tribe : System.Web.UI.Page
{

    protected Village village;
    protected Group currentTribe;
    protected ISession NHibernateSession
    {
        get;
        set;
    }

    public Group Tribe
    {
        get { return this.currentTribe; }
        set { this.currentTribe = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.village = ((inPage)this.Master).CurrentVillage;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        Player player = session.Get<Player>(Session["user"]);
        if (player.Group == null)
            Response.Redirect("untribe.aspx?id=" + this.village.ID.ToString(), false);
        
        
        int page = 0;
        int.TryParse(Request["page"], out page);
        this.navigator.Rows[0].Cells[page].Attributes.Add("class", "selected");
        switch (TribePageTypeFactory.GetTribePage(page))
        {
            case TribePageType.MembersPage:
                TribeMembers ucTribeMembers = (TribeMembers)Page.LoadControl("TribeMembers.ascx");
                ucTribeMembers.Village = village;
                ucTribeMembers.Tribe = player.Group;
                this.pTribePage.Controls.Add(ucTribeMembers);
                break;
            case TribePageType.DiplomacyPage:
                TribeDiplomacy ucDiplomacyPage = (TribeDiplomacy)Page.LoadControl("TribeDiplomacy.ascx");
                ucDiplomacyPage.DiplomacyPermission = player.TribePermission;
                ucDiplomacyPage.Village = village;
                this.pTribePage.Controls.Add(ucDiplomacyPage);
                break;
            case TribePageType.ForumPage:
                TribeShoutbox shoutbox = (TribeShoutbox)Page.LoadControl("TribeShoutbox.ascx");
                shoutbox.Group = player.Group;
                shoutbox.Size = 30;
                this.pTribePage.Controls.Add(shoutbox);
                break;
            default:
                TribeProfile ucProfilePage = (TribeProfile)Page.LoadControl("TribeProfile.ascx");
                ucProfilePage.Tribe = player.Group;
                ucProfilePage.Village = village;
                this.pTribePage.Controls.Add(ucProfilePage);
                break;
        }
    }
}
