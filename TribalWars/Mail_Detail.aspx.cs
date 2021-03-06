﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using System.Data;
public partial class Mail_detail : System.Web.UI.Page
{
    protected Village village;
    protected Mail Detail;
    protected void Page_Load(object sender, EventArgs e)
    {
        int mail_id;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        this.village = ((inPage)this.Master).CurrentVillage;
        int.TryParse(Request["mail"], out mail_id);
        Player user = session.Load<Player>(Session["user"]);
        Detail = user.GetMailDetail(mail_id, session);
        if (Detail == null)
        {
            Response.Redirect(string.Format("list_mail.aspx?id={0}", this.village), false);
        }
    }

    protected void delete_click(object sender, EventArgs e)
    {
        
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
        Player player = session.Load<Player>(Session["user"]);
        player.DeleteMail(Detail, session);
        if (Detail.From == this.village.Player)
            Response.Redirect(string.Format("list_mail.aspx?id={0}", this.village), false);
        else
            Response.Redirect(string.Format("mail_send.aspx?id={0}", this.village), false);
    }
}