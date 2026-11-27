namespace Proyecto_1._Juego_de_asteroides;
using System.Windows.Forms;

public class Window : Form
{
    
    public Window(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.Text = "Juego de asteroides";
        this.FormClosed += Window_FormClosed;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Show();
    }

    private void Window_FormClosed(object? sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

}