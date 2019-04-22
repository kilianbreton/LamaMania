using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK.IO.Xml;

namespace LAMAMAnia
{
    public partial class ConfigServ : Form
    {
        //Name ex : 01, 02, 03 ...
        
        private XmlDocument config;

        public ConfigServ()
        {
            InitializeComponent();
        }

        public ConfigServ(string index)
        {
            InitializeComponent();
            if (Config.lang != null)
                loadLang();

            this.config = new XmlDocument(@"Servers\" + index + @"\UserData\Config\dedicated_cfg.txt");
            var root = this.config.getNode(0);  //dedicated
            
            //Authorisations --------------------------------------------------------------------------
            var auth = root.getChild("authorization_levels");
            foreach(XmlNode n in auth.getChildList("level"))
            {
                switch (n.getChildV("name"))
                {
                    case "SuperAdmin":
                        tb_superPass.Text = n.getChildV("password");
                        break;

                    case "Admin":
                        tb_adminPass.Text = n.getChildV("password");
                        break;

                    case "User":
                        tb_userPass.Text = n.getChildV("password");
                        break;
                }
            }

            //Master Account --------------------------------------------------------------------------
            var master = root.getChild("masterserver_account");
            tb_serverLogin.Text = master.getChildV("login");
            tb_ServerPass.Text = master.getChildV("password");
            tb_validKey.Text = master.getChildV("validation_key");

            //Server Options --------------------------------------------------------------------------
            var servOptions = root.getChild("server_options");
            tb_ingameName.Text = servOptions.getChildV("name");
            tb_description.Text = servOptions.getChildV("comment");
            tb_playerPass.Text = servOptions.getChildV("password");
            tb_specPass.Text = servOptions.getChildV("password_spectator");
            tb_refereePass.Text = servOptions.getChildV("referee_password");
            tb_voteRatio.Text = servOptions.getChildV("callvote_ratio");

            n_voteTimeout.Value = servOptions.getChildNV("callvote_timeout");
            n_playersLimit.Value = servOptions.getChildNV("max_players");
            n_specsLimit.Value = servOptions.getChildNV("max_spectators");
            n_maxLat.Value = servOptions.getChildNV("clientinputs_maxlatency");

            ch_keepPlayerSlot.Checked = servOptions.getChildBV("keep_player_slots");
            ch_ladder.Checked = (servOptions.getChildV("ladder_mode").Equals("forced"));
            ch_p2pUp.Checked = servOptions.getChildBV("enable_p2p_upload");
            ch_p2pDown.Checked = servOptions.getChildBV("enable_p2p_download");
            ch_mapDown.Checked = servOptions.getChildBV("allow_map_download");
            ch_autoSaveReplay.Checked = servOptions.getChildBV("autosave_replays");
            ch_saveValReplay.Checked = servOptions.getChildBV("autosave_validation_replays");
        
            cb_refereeValid.SelectedIndex = (int)servOptions.getChildNV("referee_validation_mode");
            ch_horns.Checked = servOptions.getChildBV("disable_horns");

            //System Config --------------------------------------------------------------------------
            var systemConfig = root.getChild("system_config");

            n_UpRate.Value = systemConfig.getChildNV("connection_uploadrate");
            n_DownRate.Value = systemConfig.getChildNV("connection_downloadrate");

            tb_ServerPort.Text = systemConfig.getChildV("server_port");
            tb_p2pPort.Text = systemConfig.getChildV("server_p2p_port");
            tb_XmlRpcPort.Text = systemConfig.getChildV("xmlrpc_port");
            tb_proxy.Text = systemConfig.getChildV("proxy_url");

            ch_xmlRpcRemote.Checked = systemConfig.getChildBV("xmlrpc_allowremote");
            ch_proxy.Checked = systemConfig.getChildBV("use_proxy");


            tb_title.Text = systemConfig.getChildV("title");



        }

        private void b_save_Click(object sender, EventArgs e)
        {
            try
            {
                var root = this.config.getNode(0);  //dedicated

                //Authorisations --------------------------------------------------------------------------
                var auth = root.getChild("authorization_levels");
                foreach (XmlNode n in auth.getChildList("level"))
                {
                    switch (n.getChildV("name"))
                    {
                        case "SuperAdmin":
                            n.getChild("password").setValue(tb_superPass.Text);
                            break;

                        case "Admin":
                            n.getChild("password").setValue(tb_adminPass.Text);
                            break;

                        case "User":
                            n.getChild("password").setValue(tb_userPass.Text);
                            break;
                    }
                }

                //Master Account --------------------------------------------------------------------------
                var master = root.getChild("masterserver_account");
                master.getChild("login").setValue(tb_serverLogin.Text);
                master.getChild("password").setValue(tb_ServerPass.Text);
                master.getChild("validation_key").setValue(tb_validKey.Text);


                //Server Options --------------------------------------------------------------------------
                var servOptions = root.getChild("server_options");
                servOptions.getChild("name").setValue(tb_ingameName.Text);
                servOptions.getChild("comment").setValue(tb_description.Text);
                servOptions.getChild("password").setValue(tb_playerPass.Text);
                servOptions.getChild("password_spectator").setValue(tb_specPass.Text);
                servOptions.getChild("referee_password").setValue(tb_refereePass.Text);
                servOptions.getChild("callvote_ratio").setValue(tb_voteRatio.Text);

                servOptions.getChild("callvote_timeout").setValue(n_voteTimeout.Value.ToString());
                servOptions.getChild("max_players").setValue(n_playersLimit.Value.ToString());
                servOptions.getChild("max_spectators").setValue(n_specsLimit.Value.ToString());
                servOptions.getChild("clientinputs_maxlatency").setValue(n_maxLat.Value.ToString());

                servOptions.getChild("keep_player_slots").setValue(ch_keepPlayerSlot.Checked.ToString());

                if (ch_ladder.Checked)
                    servOptions.getChild("ladder_mode").setValue("forced");
                else
                    servOptions.getChild("ladder_mode").setValue("incative");

                servOptions.getChild("enable_p2p_upload").setValue(ch_p2pUp.Checked.ToString());
                servOptions.getChild("enable_p2p_download").setValue(ch_p2pDown.Checked.ToString());
                servOptions.getChild("allow_map_download").setValue(ch_mapDown.Checked.ToString());
                servOptions.getChild("autosave_replays").setValue(ch_autoSaveReplay.Checked.ToString());
                servOptions.getChild("autosave_validation_replays").setValue(ch_saveValReplay.Checked.ToString());

                servOptions.getChild("referee_validation_mode").setValue(cb_refereeValid.SelectedIndex.ToString());
                servOptions.getChild("disable_horns").setValue(ch_horns.Checked.ToString());


                //System Config --------------------------------------------------------------------------
                var systemConfig = root.getChild("system_config");

                systemConfig.getChild("connection_uploadrate").setValue(n_UpRate.Value.ToString());
                systemConfig.getChild("connection_downloadrate").setValue(n_DownRate.Value.ToString());

                systemConfig.getChild("server_port").setValue(tb_ServerPort.Text);
                systemConfig.getChild("server_p2p_port").setValue(tb_p2pPort.Text);
                systemConfig.getChild("xmlrpc_port").setValue(tb_XmlRpcPort.Text);
                systemConfig.getChild("proxy_url").setValue(tb_proxy.Text);

                systemConfig.getChild("xmlrpc_allowremote").setValue(ch_xmlRpcRemote.Checked.ToString());
                systemConfig.getChild("use_proxy").setValue(ch_proxy.Checked.ToString());


                systemConfig.getChild("title").setValue(tb_title.Text);
                this.config.save();
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
               
            }

        }


        void loadLang()
        {
           
        }

    }
}
