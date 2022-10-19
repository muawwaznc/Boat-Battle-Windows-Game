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
    public partial class Level1_forrm : Form
    {
        System.Random rnd = new System.Random();
        int game_count = 1;
        Game g = new Game();

        public Level1_forrm()
        {
            InitializeComponent();
        }

        private void Level1_Load(object sender, EventArgs e)
        {
            g.on_GameObject_added += new EventHandler(addObjectsInControls);            
            makingGameObjects();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
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
            makingEnemies();
            makingEnemyFire();
            g.Collision();
            if (g.Details.Score >= 300)
            {
                gameLoop.Enabled = false;
                g.Details.Level++;
                g.clearList();
                Level2_form new_form = new Level2_form(g);
                this.Hide();
                new_form.Show();
            }
            checkCrash();
            updateScore();
            if(game_count % 200 == 0)
            {
                int Y = rnd.Next(300, 700);
                int X = rnd.Next(0, 1382);
                if(X > 1382/2)
                {
                    g.Add_GameObject(Boatbattle.Properties.Resources.laserRed10, Y, 1382, new Projectile(20, new Point(this.Width, this.Height), "left"), GameObjectTypes.EnemyFire, 100);
                }
                else
                {
                    g.Add_GameObject(Boatbattle.Properties.Resources.laserRed10, Y, 0, new Projectile(20, new Point(this.Width, this.Height), "right"), GameObjectTypes.EnemyFire, 100);
                }
                
            }  // For Big bomb

            if(game_count % 450 == 0)
            {
                makeingNewLife();                
            }
            if(game_count % 300 == 0)
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
            if(e.KeyCode == Keys.Space)
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
            if(game_count % 40 == 0)
            {
                g.Add_GameObject(Boatbattle.Properties.Resources.enemy_boat, random, 0, new Horizontal(20, formBoundry, "right", false, true), GameObjectTypes.Enemy, 1);
            }
            else if (game_count % 60 == 0)
            {
                g.Add_GameObject(Boatbattle.Properties.Resources.enemy_boat, random, 1382, new Horizontal(20, formBoundry, "left", true, false), GameObjectTypes.Enemy, 1);
            }
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
            g.Add_GameObject(Boatbattle.Properties.Resources.heart1, this.Height, left, new Vertical(20, formBoundry, "up", true , false), GameObjectTypes.Live, 100);
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
