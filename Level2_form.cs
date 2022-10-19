using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Movement;
using Framework.Core;

namespace Boatbattle
{
    public partial class Level2_form : Form
    {
        System.Random rnd = new System.Random();
        int game_count = 1;
        int score;
        Game g;


        public Level2_form(Game g)
        {
            this.g = g;
            InitializeComponent();
            score = g.Details.Score;
        }

        private void Level2_form_Load(object sender, EventArgs e)
        {
            g.on_GameObject_added += new EventHandler(addObjectsInControls);
            makingGameObjects();
            gameLoop.Enabled = true;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            //g = Level1_forrm.getG();
        }

        private void makingGameObjects()
        {
            Point formBoundry = new Point(this.Width, this.Height);
            g.Add_GameObject(Boatbattle.Properties.Resources.left_boat_sized, 130, 549, new Keyboard(40, formBoundry, true, true, false, false), GameObjectTypes.Player, 3);
        }

        private void updateScore()
        {
            lblScore.Text = "Score " + g.Details.Score;
            lblLives.Text = "Lives " + g.getPlayerLives();
            lblLevel.Text = "Level " + g.Details.Level;
        }

        private void checkCrash()
        {
            if (g.getPlayerLives() == 0)
            {
                gameLoop.Enabled = false;
                GameOver_form new_form = new GameOver_form();
                this.Hide();
                new_form.Show();
            }
        }

        private void lbl_mainMenu_Click(object sender, EventArgs e)
        {
            gameLoop.Enabled = false;
            MainMenu_form new_form = new MainMenu_form();
            this.Hide();
            new_form.Show();
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            g.on_isObjectExist += new EventHandler(removeObjectsFromControls);
            g.Update();
            g.isObjectExist(new Point(this.Width, this.Height));
            if(game_count == 5)
            {
                makingEnemies();
            }            
            makingEnemyFire();
            g.Collision();
            if (g.Details.Score == score + 20)
            {
                gameLoop.Enabled = false;
                MessageBox.Show("Level completed");
                MainMenu_form new_form = new MainMenu_form();
                this.Hide();
                new_form.Show();
            }
            checkCrash();
            updateScore();
             // For Big bomb

            if (game_count % 450 == 0)
            {
                makeingNewLife();
            }
            if (game_count % 300 == 0)
            {
                makingFishEnemy();
            }
            game_count++;
        }

        private void throwBomb(object sender, EventArgs e)
        {
            Point formBoundry = new Point(this.Width, this.Height);
            Point player = g.getPlayerPoint();
            g.Add_GameObject(Boatbattle.Properties.Resources.laserGreen11, player.Y, player.X, new Vertical(40, formBoundry, "down", false, true), GameObjectTypes.PlayerFire, 100);
        }

        private void Level1_KeyDown(object sender, KeyEventArgs e)
        {
            g.KeyPressed(e.KeyCode);
            if (e.KeyCode == Keys.Space)
            {
                throwBomb(sender, e);
            }
        }

        private void addObjectsInControls(object sender, EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }

        private void removeObjectsFromControls(object sender, EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
        }

        private void makingEnemies()
        {
            int random = rnd.Next(400, 700);
            Point formBoundry = new Point(this.Width, this.Height);
            g.Add_GameObject(Boatbattle.Properties.Resources.enemy_boat_2, random, 0, new Horizontal(20, formBoundry, "right", true, true), GameObjectTypes.Enemy, 10);
            g.Add_GameObject(Boatbattle.Properties.Resources.enemy_boat_2, random, 1382, new Horizontal(20, formBoundry, "left", true, true), GameObjectTypes.Enemy, 10);            
        }

        private void makingEnemyFire()
        {
            if (game_count % 15 == 0)
            {
                Point formBoundry = new Point(this.Width, this.Height);
                List<GameObject> enemies = g.getEnemiesList();
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        g.Add_GameObject(Boatbattle.Properties.Resources.laserRed03, enemies[i].Pb.Top + 2, enemies[i].Pb.Left, new Vertical(20, formBoundry, "up", true, false), GameObjectTypes.EnemyFire, 100);
                    }
                }
            }
        }

        private void makeingNewLife()
        {
            int left = rnd.Next(20, 1300);
            Point formBoundry = new Point(this.Width, this.Height);
            g.Add_GameObject(Boatbattle.Properties.Resources.heart1, this.Height, left, new Vertical(20, formBoundry, "up", true, false), GameObjectTypes.Live, 100);
        }

        private void makingFishEnemy()
        {
            int top = rnd.Next(400, 600);
            int left = rnd.Next(20, 1300);
            Point formBoundry = new Point(this.Width, this.Height);
            g.Add_GameObject(Boatbattle.Properties.Resources.shark, top, left, new RandomMotion(50), GameObjectTypes.Fish, 3);

        }
    }
}
