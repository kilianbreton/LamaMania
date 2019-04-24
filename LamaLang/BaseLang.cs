/* ----------------------------------------------------------------------------------
 * Project : LamaMania
 * Launch Authenticate Manage & Access ManiaPlanet Servers
 * Inspired by ServerMania by Cyrlaur
 * 
 * ----------------------------------------------------------------------------------
 * Author:	    Breton Kilian
 * Copyright:	April 2019 by Breton Kilian
 * ----------------------------------------------------------------------------------
 *
 * LICENSE: This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>.
 *
 * ----------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LamaLang
{
    public abstract class BaseLang
    {
        public abstract string getHLStart();
        public abstract string getHLTitle();
        public abstract string getHLEdit();
        public abstract string getHLRemove();

        public abstract string getCSTitle();
        public abstract string getCSTabGeneral();
        public abstract string getCSTabAdvanced();
        public abstract string getCSMatchSettings();

        public abstract string getCSGeneralName();
        public abstract string getCSGeneralTitle();
        public abstract string getCSGeneralIngameName();
        public abstract string getCSGeneralDescription();
        public abstract string getCSGeneralPlayerPass();
        public abstract string getCSGeneralSpecPass();
        public abstract string getCSGeneralPlayersLimit();
        public abstract string getCSGeneralSpecsLimit();
        public abstract string getCSGeneralServerLogin();
        public abstract string getCSGeneralServerPass();
        public abstract string getCSGeneralValidKey();
        public abstract string getCSGeneralSuperAdmin();
        public abstract string getCSGeneralAdmin();
        public abstract string getCSGeneralUser();

        public abstract string getCSAdvancedRefereePass();
        public abstract string getCSAdvancedRefereeVal();
        public abstract string getCSAdvancedVoteTimeout();
        public abstract string getCSAdvancedVoteRatio();
        public abstract string getCSAdvancedForceLadder();
        public abstract string getCSAdvancedKeepPlayerSlot();
        public abstract string getCSAdvancedAutoSaveReplays();
        public abstract string getCSAdvancedSaveValidationReplays();
        public abstract string getCSAdvancedMapDownload();
        public abstract string getCSAdvancedDisableHorns();
        public abstract string getCSAdvancedServerPort();
        public abstract string getCSAdvancedP2PPort();
        public abstract string getCSAdvancedXMLRPCPort();
        public abstract string getCSAdvancedMaxLatency();
        public abstract string getCSAdvancedDownRate();
        public abstract string getCSAdvancedUpRate();
        public abstract string getCSAdvancedProxy();
        public abstract string getCSAdvancedXMLRPCAllowRemote();
        public abstract string getCSAdvancedP2PDown();
        public abstract string getCSAdvancedP2PUp();

        public abstract string getCSCancel();
        public abstract string getCSSave();

        public abstract string getMainTitle();
        public abstract string getMTabMain();
        public abstract string getMtabChat();
        public abstract string getMTabUsers();
        public abstract string getMTabMaps();
        public abstract string getMTabMatchSettings();
        public abstract string getMTabPlugins();
        public abstract string getMMStatusTitle();
        public abstract string getMMStatusXmlRpc();
        public abstract string getMMStatusServer();
        public abstract string getMMSUaseco();
        public abstract string getMMGameInfosTitle();
        public abstract string getMMGameInfosGameMode();
        public abstract string getMMGameInfosMap();
        public abstract string getMMGameInfosPlayers();
        public abstract string getMMGameInfosPrevious();
        public abstract string getMMGameInfoRestart();
        public abstract string getMMGameInfoNext();
        public abstract string getMMGameInfoStopRound();
        public abstract string getMMGameInfoMakeNext();
        public abstract string getMMGameInfoJoin();
        public abstract string getMMPlayersTitle();
        public abstract string getMMServerInfosTitle();
        public abstract string getMMServerInfosName();
        public abstract string getMMServerInfosDescription();

    //    public abstract string getMMServerInfosTitle();
      //  public abstract string getMMServerInfosTitle();

    }
}
