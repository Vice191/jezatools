using System.Collections;

namespace Library
{
    public class ServerData
    {
		//http://s3.travian.si/dorf1.php
		//http://s3.travian.si/dorf2.php
		//http://s3.travian.si/karte.php
		//http://s3.travian.si/statistiken.php
		//http://s3.travian.si/berichte.php
		//http://s3.travian.si/nachrichten.php
		
		private ArrayList buildingsList = new ArrayList();
        private string hiddenLoginValue;
        private string hiddenName;
        private string hiddenValue;
        private string password ="kepek";
        private int playerUID;
		private string servername = "http://s3.travian.si/";

        private string textboxLoginName;
        private string textboxLoginValue;
        private string textboxPasswordName;
        private string textboxPasswordValue;
        private string username = "jezonsky";

        private ArrayList villagesList = new ArrayList();
        private ArrayList productionList = new ArrayList();
        private ArrayList resourcesList = new ArrayList();

        private string emptyLandName = "zazidljiva parcela";
        private string emptyCityWall = "zunanje gradbišče";
    	private string emptyRallyPoint = "območje za zbirališče";

    	/// <summary>
        /// Login Username.
        /// </summary>
        /// <example>jezonsky</example>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Login password.
        /// </summary>
        /// <example>somepassword</example>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Server URL.
        /// </summary>
        /// <example>http://s3.travian.si/</example>
        public string Servername
        {
            get { return servername; }
            set { servername = value; }
        }

        /// <summary>
        /// <input class="fm fm110" type="text" name="e528e90" value="" maxlength="15">
        /// </summary>
        /// <example>name="e528e90"</example>
        public string TextboxLoginName
        {
            get { return textboxLoginName; }
            set { textboxLoginName = value; }
        }

        /// <summary>
        /// <input class="fm fm110" type="text" name="e528e90" value="" maxlength="15">
        /// </summary>
        /// <example>value=""</example>
        public string TextboxLoginValue
        {
            get { return textboxLoginValue; }
            set { textboxLoginValue = value; }
        }

        /// <summary>
        /// <input class="fm fm110" type="password" name="e4519e5" value="" maxlength="20">
        /// </summary>
        /// <example>name="e4519e5"</example>
        public string TextboxPasswordName
        {
            get { return textboxPasswordName; }
            set { textboxPasswordName = value; }
        }

        /// <summary>
        /// <input class="fm fm110" type="password" name="e4519e5" value="" maxlength="20">
        /// </summary>
        /// <example>value=""</example>
        public string TextboxPasswordValue
        {
            get { return textboxPasswordValue; }
            set { textboxPasswordValue = value; }
        }

        /// <summary>
        /// <input type="hidden" name="login" value="1218716929">
        /// </summary>
        /// <example>value="1218716929"</example>
        public string HiddenLoginValue
        {
            get { return hiddenLoginValue; }
            set { hiddenLoginValue = value; }
        }

        /// <summary>
        /// <input type="hidden" name="eea0521" value="">
        /// </summary>
        /// <example>name="eea0521"</example>
        public string HiddenName
        {
            get { return hiddenName; }
            set { hiddenName = value; }
        }

        /// <summary>
        /// <input type="hidden" name="eea0521" value="">
        /// </summary>
        /// <example>value=""</example>
        public string HiddenValue
        {
            get { return hiddenValue; }
            set { hiddenValue = value; }
        }

        /// <summary>
        /// //<a href="spieler.php?uid=8226">Profil</a>
        /// </summary>
        public int PlayerUID
        {
            get { return playerUID; }
            set { playerUID = value; }
        }

        /// <summary>
        /// <a href="?newdid=10902">Muta01</a>
        /// <a href="?newdid=10903">Muta02</a>
        /// ...
        /// </summary>
        /// <remarks>
        /// List is in format villageID|villageName
        /// </remarks>
        /// <example>
        /// 10902|Muta01
        /// </example>
        public ArrayList VillagesList
        {
            get { return villagesList; }
            set { villagesList = value; }
        }

        public ArrayList ProductionList
        {
            get { return productionList; }
            set { productionList = value; }
        }

        public ArrayList ResourcesList
        {
            get { return resourcesList; }
            set { resourcesList = value; }
        }


        public ArrayList BuildingsList
        {
            get { return buildingsList; }
            set { buildingsList = value; }
        }

        public string EmptyLandName
        {
            get { return emptyLandName; }
            set { emptyLandName = value; }
        }

        public string EmptyCityWall
        {
            get { return emptyCityWall; }
            set { emptyCityWall = value; }
        }

		public string EmptyRallyPoint
		{
			get { return emptyRallyPoint; }
			set { emptyRallyPoint = value; }
		}

		public override string ToString()
        {
            return
                string.Format(
                    "Username: {0}, Password: {1}, Servername: {2}, TextboxLoginName: {3}, TextboxLoginValue: {4}, TextboxPasswordName: {5}, TextboxPasswordValue: {6}, HiddenLoginValue: {7}, HiddenName: {8}, HiddenValue: {9}, PlayerUID: {10}",
                    username, password, servername, textboxLoginName, textboxLoginValue, textboxPasswordName,
                    textboxPasswordValue, hiddenLoginValue, hiddenName, hiddenValue, playerUID);
        }
    }
}