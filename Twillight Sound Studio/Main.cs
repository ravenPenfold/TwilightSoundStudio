using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwlSoundLibrary.Formats;
using TwlSoundLibrary.Data;

namespace Twillight_Sound_Studio
{
    public partial class Main : Form
    {
        Archive archive;
        private void UpdateView(int group)
        {
            itemsList.Items.Clear();
            foreach (var i in archive.EntryNames[group])
            {
                itemsList.Items.Add("[" + i.Id.ToString("0000") + "] " + i.Name);
            }
            itemsList.Sorting = SortOrder.Ascending;
            itemsList.Sort();
        }

        private void UpdateView(FileTypes type)
        {
            UpdateView((int)type);
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            sndGrpDropdown.SelectedIndex = 0;
            itemsList.View = View.List;
            noId.Maximum = uint.MaxValue;
        }

        private void sndGrpDropdown_Click(object sender, EventArgs e)
        {

        }

        private void openSoundArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Sound Archive|*.sdat";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                archive = new Archive(ofd.FileName);
            }
            sndGrpDropdown.SelectedIndex = 0;
            UpdateView(sndGrpDropdown.SelectedIndex);
        }

        private void sndGrpDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (archive != null)
            {
                UpdateView(sndGrpDropdown.SelectedIndex);
            }
        }

        private void itemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemsList.SelectedIndices.Count > 0)
            {
                var split = itemsList.SelectedItems[0].Text.Replace("[", "").Replace("]", "").Split(" ");
                noId.Value = int.Parse(split[0]);
                txtName.Text = split[1];

                label3.Text = "";
                var grp = (FileTypes)sndGrpDropdown.SelectedIndex;

                switch(grp)
                {
                    case FileTypes.Sequence:
                        SequenceInfo si = archive.SeqInfo[int.Parse(split[0])];
                        label3.Text = "File ID: " + si.FileId +
                            "\nBank ID: " + si.BankAssoc +
                            "\nC.Prio: " + si.ChannelPrio +
                            "\nP.Prio: " + si.PlayerPrio +
                            "\nPlayer ID: " + si.PlayerAssoc;
                        break;

                    case FileTypes.SequenceArchive:
                        SequenceArchiveInfo sai = archive.SarcInfo[int.Parse(split[0])];
                        label3.Text = "File ID: " + sai.FileId;
                        break;

                    case FileTypes.Bank:
                        BankInfo bi = archive.BnkInfo[int.Parse(split[0])];
                        label3.Text = "File ID: " + bi.FileId;
                        break;
                }
            }
        }

        private void btnUpdateGlobal_Click(object sender, EventArgs e)
        {
            var split = itemsList.SelectedItems[0].Text.Replace("[", "").Replace("]", "").Split(" ");
            int id = int.Parse(split[0]);
            int grp = sndGrpDropdown.SelectedIndex;
            archive.EntryNames.ElementAt(grp).Remove(archive.EntryNames.ElementAt(grp)[id]);
            archive.EntryNames.ElementAt(grp).Add(new Filename((uint)noId.Value, txtName.Text));
            UpdateView(sndGrpDropdown.SelectedIndex);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filter = "";
            string extension = "";
            switch ((FileTypes)sndGrpDropdown.SelectedIndex)
            {
                case FileTypes.Sequence:
                    filter = "Nitro Sequence File|*.sseq";
                    extension = ".sseq";
                    break;
                case FileTypes.SequenceArchive:
                    filter = "Nitro SequenceArchive File|*.ssar";
                    extension = ".ssar";
                    break;
                case FileTypes.Bank:
                    filter = "Nitro Bank File|*.sbnk";
                    extension = ".sbnk";
                    break;
                case FileTypes.WaveArchive:
                    filter = "Nitro WaveArchive File|*.swar";
                    extension = ".swar";
                    break;
                case FileTypes.Stream:
                    filter = "Nitro Streamed Audio File|*.strm";
                    extension = ".strm";
                    break;
                default:
                    return;
            }
            if (itemsList.SelectedItems.Count != 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                var split = itemsList.SelectedItems[0].Text.Replace("[", "").Replace("]", "").Split(" ");
                sfd.FileName = split[1] + extension;
                sfd.Filter = filter;
                DialogResult dr = sfd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    byte[] data;
                    switch ((FileTypes)sndGrpDropdown.SelectedIndex)
                    {
                        case FileTypes.Sequence:
                            data = archive.Data[(int)archive.SeqInfo[int.Parse(split[0])].FileId];
                            break;
                        case FileTypes.SequenceArchive:
                            filter = "Nitro SequenceArchive File|*.ssar";
                            data = archive.Data[(int)archive.SarcInfo[int.Parse(split[0])].FileId];
                            extension = ".ssar";
                            break;
                        case FileTypes.Bank:
                            filter = "Nitro Bank File|*.sbnk";
                            data = archive.Data[(int)archive.BnkInfo[int.Parse(split[0])].FileId];
                            extension = ".sbnk";
                            break;
                        case FileTypes.WaveArchive:
                            filter = "Nitro WaveArchive File|*.swar";
                            data = archive.Data[(int)archive.WaveArcInfo[int.Parse(split[0])].FileId];
                            extension = ".swar";
                            break;
                        case FileTypes.Stream:
                            filter = "Nitro Streamed Audio File|*.strm";
                            data = archive.Data[(int)archive.StmInfo[int.Parse(split[0])].FileId];
                            extension = ".strm";
                            break;
                        default:
                            return;
                    }
                    File.WriteAllBytes(sfd.FileName, data);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string filter = "";
            string extension = "";
            switch ((FileTypes)sndGrpDropdown.SelectedIndex)
            {
                case FileTypes.Sequence:
                    filter = "Nitro Sequence File|*.sseq";
                    extension = ".sseq";
                    break;
                case FileTypes.SequenceArchive:
                    filter = "Nitro SequenceArchive File|*.ssar";
                    extension = ".ssar";
                    break;
                case FileTypes.Bank:
                    filter = "Nitro Bank File|*.sbnk";
                    extension = ".sbnk";
                    break;
                case FileTypes.WaveArchive:
                    filter = "Nitro WaveArchive File|*.swar";
                    extension = ".swar";
                    break;
                case FileTypes.Stream:
                    filter = "Nitro Streamed Audio File|*.strm";
                    extension = ".strm";
                    break;
                default:
                    return;
            }
            if (itemsList.SelectedItems.Count != 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                var split = itemsList.SelectedItems[0].Text.Replace("[", "").Replace("]", "").Split(" ");
                ofd.Filter = filter;
                DialogResult dr = ofd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    uint dataId;
                    switch ((FileTypes)sndGrpDropdown.SelectedIndex)
                    {
                        case FileTypes.Sequence:
                            dataId = archive.SeqInfo[int.Parse(split[0])].FileId;
                            break;
                        case FileTypes.SequenceArchive:
                            filter = "Nitro SequenceArchive File|*.ssar";
                            dataId = archive.SarcInfo[int.Parse(split[0])].FileId;
                            extension = ".ssar";
                            break;
                        case FileTypes.Bank:
                            filter = "Nitro Bank File|*.sbnk";
                            dataId = archive.BnkInfo[int.Parse(split[0])].FileId;
                            extension = ".sbnk";
                            break;
                        case FileTypes.WaveArchive:
                            filter = "Nitro WaveArchive File|*.swar";
                            dataId = archive.WaveArcInfo[int.Parse(split[0])].FileId;
                            extension = ".swar";
                            break;
                        case FileTypes.Stream:
                            filter = "Nitro Streamed Audio File|*.strm";
                            dataId = archive.StmInfo[int.Parse(split[0])].FileId;
                            extension = ".strm";
                            break;
                        default:
                            return;
                    }
                    archive.Data[(int)dataId] = File.ReadAllBytes(ofd.FileName);
                }
            }
        }

        private void saveSoundArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archive.SaveFile(archive.Filename);
        }
    }
}
