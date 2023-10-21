using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weasel_Server_MapViewer
{
    public partial class Form_Weasel_Server_Map_Viewer : Form
    {
        private List<Label> _Labels_Waypoints;
        private List<Label> _Labels_Lanes;
        private Timer _UpdateMap;

        public Form_Weasel_Server_Map_Viewer()
        {
            //Build the map
            InitializeComponent();
            _Labels_Waypoints = new List<Label>();
            _Labels_Lanes = new List<Label>();
            LoadMap();

            //Create the Thread to check the map
            _UpdateMap = new Timer();
            _UpdateMap.Tick += MapUpdater;
            _UpdateMap.Interval = 100;
            _UpdateMap.Start();
        }

        private void LoadMap()
        {
            //Get Waypoints
            string path = "MapPanel_Waypoints.txt";
            string[] txt_MapPanel = System.IO.File.ReadAllLines(path);
            int count_Labels_Waypoints = 0;
            for (int i = 0; i < txt_MapPanel.Length; i = i + 2)
            {
                Label newLabel = new Label();
                newLabel.Text = txt_MapPanel[i];
                string[] split = txt_MapPanel[i + 1].Split(' ');
                newLabel.Location = new Point(Int32.Parse(split[0]), Int32.Parse(split[1]));
                newLabel.BackColor = Color.LightGreen;
                newLabel.AccessibleDescription = "WayPointEdit";
                newLabel.Size = new Size(40, 15);
                newLabel.TextAlign = ContentAlignment.MiddleCenter;
                _Labels_Waypoints.Add(newLabel);
                this.Controls.Add(_Labels_Waypoints[count_Labels_Waypoints]);
                count_Labels_Waypoints++;
            }

            //Get lanes
            string path2 = "MapPanel_Lanes.txt";
            string[] txt_MapPanel2 = System.IO.File.ReadAllLines(path2);
            for (int i = 0; i < txt_MapPanel2.Length; i = i + 2)
            {
                Label newLabel = new Label();
                newLabel.Text = "   ";
                newLabel.BackColor = Color.LightGray;
                newLabel.AccessibleDescription = "LaneEdit";
                string[] split1 = txt_MapPanel2[i + 1].Split(' ');
                newLabel.Location = new Point(Int32.Parse(split1[0]), Int32.Parse(split1[1]));
                newLabel.TextAlign = ContentAlignment.MiddleCenter;
                string[] split2 = txt_MapPanel2[i].Split(' ');
                newLabel.Size = new Size(Int32.Parse(split2[0]), Int32.Parse(split2[1]));
                _Labels_Lanes.Add(newLabel);
                this.Controls.Add(_Labels_Lanes[_Labels_Lanes.Count - 1]);
            }
        }

        private void MapUpdater(object sender, EventArgs e)
        {
            //Get the request and check the map with it
            GETRequest.Request("http://localhost:9999/map");
            string request = GETRequest.Result;

            if (request != null)
            {
                //Tell that it is online
                label_Online.Text = "Online: true";

                //Disassembly the JSON
                List<WaypointJSON> waypoints = JsonConvert.DeserializeObject<List<WaypointJSON>>(request);

                //Check with every label if the status is still correct
                for (int i = 0; i < waypoints.Count; i++)
                {
                    CheckWaypoint(waypoints[i]);
                }
            }
            else
            {
                label_Online.Text = "Online: false";
            }
        }

        private void CheckWaypoint(WaypointJSON waypoint)
        {
            for(int i = 0; i < _Labels_Waypoints.Count; i++)
            {
                if(waypoint._PointID == Int32.Parse(_Labels_Waypoints[i].Text))
                {
                    _Labels_Waypoints[i].BackColor = Color.FromName(waypoint._ReservedColorName);
                }
            }
        }
    }
}
