using System;
using System.Windows.Forms;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace Client
{
    public partial class Form1 : Form
    {
        private readonly IMobileServiceSyncTable<TodoItem> _todoTable = Program.TableClient.GetSyncTable<TodoItem>();
        public Form1()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private static async void OnLoad(object sender, EventArgs eventArgs)
        {
            const string path = "bd.sqlite";
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<TodoItem>();
            await Program.TableClient.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
        }

        //Insert
        private async void Button1Click(object sender, EventArgs e)
        {
            await _todoTable.InsertAsync(new TodoItem
            {
                Text = "Task "+ DateTime.Now.Ticks,
                Complete = false
            });
        }

        private async void Button2Click(object sender, EventArgs e)
        {
            string errorString = null;
            try
            {
                await _todoTable.PullAsync(_todoTable.Where(x => x.Complete == false));
            }
            catch (MobileServicePushFailedException ex)
            {
                errorString = "Internal Push operation during pull request failed because of sync errors: " +
                  ex.PushResult.Errors.Count + " errors, message: " + ex.Message;
            }
            catch (Exception ex)
            {
                errorString = "Pull failed: " + ex.Message +
                  "\n\nIf you are still in an offline scenario, " +
                  "you can try your Pull again when connected with your Mobile Serice.";
            }

            if (errorString != null)
            {
                MessageBox.Show(errorString);
                return;
            }
            try
            {
                await Program.TableClient.SyncContext.PushAsync();
            }
            catch (MobileServicePushFailedException ex)
            {
                errorString = "Push failed because of sync errors: " +
                  ex.PushResult.Errors.Count + " errors, message: " + ex.Message;
            }
            catch (Exception ex)
            {
                errorString = "Push failed: " + ex.Message +
                  "\n\nIf you are still in an offline scenario, " +
                  "you can try your Push again when connected with your Mobile Serice.";
            }

            if (errorString != null)
            {
                MessageBox.Show(errorString);
            }
        }
    }
}
