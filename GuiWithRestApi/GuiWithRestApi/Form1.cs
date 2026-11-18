using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GuiWithRestApi
{
    public partial class Form1 : Form
    {
        private readonly PostService _postService;
        private List<Post> _posts;

        public Form1()
        {
            InitializeComponent();
            _postService = new PostService();
            _posts = new List<Post>();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            lblStatus.Text = "Статус: Завантаження даних...";

            try
            {
                _posts = await _postService.GetPostsAsync();

                listBoxPosts.DataSource = null;
                listBoxPosts.DataSource = _posts;
                listBoxPosts.DisplayMember = "Title";

                lblCount.Text = $"Отримано публікацій: {_posts.Count}";
                lblStatus.Text = "Статус: Дані успішно завантажено.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Статус: Помилка завантаження.";
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoad.Enabled = true;
            }
        }

        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPosts.SelectedItem is Post selectedPost)
            {
                lblSelectedId.Text = $"ID: {selectedPost.Id}";
                lblSelectedTitle.Text = $"Заголовок: {selectedPost.Title}";
                txtSelectedBody.Text = $"Текст:\r\n{selectedPost.Body}";
            }
        }
    }
}