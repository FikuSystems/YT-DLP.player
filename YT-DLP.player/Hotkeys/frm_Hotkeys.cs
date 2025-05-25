using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YT_DLP.player;
using YT_DLP.player.controls;

namespace YT_DLP.player.Hotkeys
{
    public partial class frm_Hotkeys : Form
    {
        public frm_Hotkeys()
        {
            InitializeComponent();
            WireHotkeyButtonEvents();
            KeyActionText.TextChanged += KeyActionText_TextChanged;
            ClearActionButton.Click += ClearActionButton_Click;
        }
        private string GetHotkeyPropertyName(string btnName)
        {
            string key = btnName.Replace("Hotkey", "");
            if (key.Length == 1 && char.IsDigit(key[0]))
            {
                return key == "0" ? "K0" : $"K{key}";
            }
            return key;
        }
        private void frm_Hotkeys_Load(object sender, EventArgs e)
        {
            // Load hotkeys from settings
            LoadHotkeys();
        }
        private void HotkeyPreviewAssignment(Button control, string hotkeyAction)
        {
            ToolTip.SetToolTip(control, hotkeyAction);
            if (string.IsNullOrEmpty(hotkeyAction)) { }
            else
            {
                //control.Text = $"{control.Text}";
                control.FlatAppearance.BorderColor = Color.FromArgb(50, 110, 235);
            }
        }
        private DLPButtonHotkey _selectedHotkeyButton = null;
        private string _selectedHotkeyName = null;
        private string _originalAction = null;
        private void WireHotkeyButtonEvents()
        {
            foreach (var ctrl in KeyboardPanel.Controls)
            {
                if (ctrl is DLPButtonHotkey btn)
                {
                    btn.Click += HotkeyButton_Click;
                }
            }
        }
        private void ResetDefaultButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to reset all Hotkeys to their default values?",
                "YT-DLP Player - Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;
            // Reset all user-scoped settings to their default values
            HotKeys.Default.Reset();

            // Save the reset values to disk
            HotKeys.Default.Save();

            // Clear any pending (unsaved) assignments
            _pendingHotkeyAssignments.Clear();

            // Reload the UI to reflect the defaults
            LoadHotkeys();

            // If a hotkey is currently selected, update the preview and text box
            if (_selectedHotkeyButton != null)
            {
                var prop = typeof(HotKeys).GetProperty(_selectedHotkeyName);
                string defaultAction = prop?.GetValue(HotKeys.Default)?.ToString() ?? "";
                _originalAction = defaultAction;
                KeyActionText.Text = defaultAction;
                ToolTip.SetToolTip(_selectedHotkeyButton, defaultAction);
                UpdateHotkeyPreviewColor(_selectedHotkeyButton, defaultAction, defaultAction);
            }
        }
        private void HotkeyButton_Click(object sender, EventArgs e)
        {
            if (sender is DLPButtonHotkey btn)
            {
                _selectedHotkeyButton = btn;
                _selectedHotkeyName = GetHotkeyPropertyName(btn.Name);

                // Check for pending (unsaved) assignment first
                string action;
                // Always get the original (saved) value from settings
                var prop = typeof(HotKeys).GetProperty(_selectedHotkeyName);
                string savedAction = prop?.GetValue(HotKeys.Default)?.ToString() ?? "";
                _originalAction = savedAction;

                if (_pendingHotkeyAssignments.TryGetValue(_selectedHotkeyName, out var pendingAction))
                {
                    action = pendingAction;
                }
                else
                {
                    action = savedAction;
                }
                KeyActionText.Text = action;
                HotkeyPreviewKey.Text = btn.Text;
                HotkeyPreviewKey.FlatAppearance.BorderColor = btn.FlatAppearance.BorderColor;
            }
        }
        private void KeyActionText_TextChanged(object sender, EventArgs e)
        {
            if (_selectedHotkeyButton == null) return;

            string newAction = KeyActionText.Text;
            ToolTip.SetToolTip(_selectedHotkeyButton, newAction);
            _pendingHotkeyAssignments[_selectedHotkeyName] = newAction;
            UpdateHotkeyPreviewColor(_selectedHotkeyButton, newAction, _originalAction);
        }

        private void ClearActionButton_Click(object sender, EventArgs e)
        {
            KeyActionText.Text = "";
        }

        private void UpdateHotkeyPreviewColor(DLPButtonHotkey btn, string newAction, string originalAction)
        {
            if (string.IsNullOrEmpty(originalAction) && string.IsNullOrEmpty(newAction))
            {
                // Unassigned (never had an action)
                btn.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
                HotkeyPreviewKey.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            }
            else if (!string.IsNullOrEmpty(originalAction) && string.IsNullOrEmpty(newAction))
            {
                // Cleared (was assigned, now empty)
                btn.FlatAppearance.BorderColor = Color.FromArgb(240, 0, 54);
                HotkeyPreviewKey.FlatAppearance.BorderColor = Color.FromArgb(240, 0, 54);
            }
            else if (newAction != originalAction)
            {
                // Changed (including assigned for the first time)
                btn.FlatAppearance.BorderColor = Color.FromArgb(230, 200, 50);
                HotkeyPreviewKey.FlatAppearance.BorderColor = Color.FromArgb(230, 200, 50);
            }
            else
            {
                // Assigned (saved)
                btn.FlatAppearance.BorderColor = Color.FromArgb(50, 110, 235);
                HotkeyPreviewKey.FlatAppearance.BorderColor = Color.FromArgb(50, 110, 235);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var ctrl in KeyboardPanel.Controls)
            {
                if (ctrl is DLPButtonHotkey btn)
                {
                    string keyName = GetHotkeyPropertyName(btn.Name);
                    var prop = typeof(HotKeys).GetProperty(keyName);
                    if (prop != null)
                    {
                        // Use the pending assignment if available, else the tooltip (for safety)
                        string action = _pendingHotkeyAssignments.TryGetValue(keyName, out var pendingAction)
                            ? pendingAction
                            : ToolTip.GetToolTip(btn);
                        prop.SetValue(HotKeys.Default, action);
                    }
                }
            }
            HotKeys.Default.Save();
            this.Close();
        }
        private void HotkeyActionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Only allow leaf nodes (actions, not categories)
            if (e.Node.Nodes.Count == 0)
            {
                string action = e.Node.Text;
                KeyActionText.Text = action;
                // Optionally, update the tooltip and color immediately
                if (_selectedHotkeyButton != null)
                {
                    ToolTip.SetToolTip(_selectedHotkeyButton, action);
                    UpdateHotkeyPreviewColor(_selectedHotkeyButton, action, _originalAction);
                }
            }
        }
        private Dictionary<string, string> _pendingHotkeyAssignments = new();
        private void LoadHotkeys()
        {
            _pendingHotkeyAssignments.Clear();
            HotkeyPreviewAssignment(HotkeyQ, YT_DLP.player.Hotkeys.HotKeys.Default.Q);
            HotkeyPreviewAssignment(HotkeyW, YT_DLP.player.Hotkeys.HotKeys.Default.W);
            HotkeyPreviewAssignment(HotkeyE, YT_DLP.player.Hotkeys.HotKeys.Default.E);
            HotkeyPreviewAssignment(HotkeyR, YT_DLP.player.Hotkeys.HotKeys.Default.R);
            HotkeyPreviewAssignment(HotkeyT, YT_DLP.player.Hotkeys.HotKeys.Default.T);
            HotkeyPreviewAssignment(HotkeyY, YT_DLP.player.Hotkeys.HotKeys.Default.Y);
            HotkeyPreviewAssignment(HotkeyU, YT_DLP.player.Hotkeys.HotKeys.Default.U);
            HotkeyPreviewAssignment(HotkeyI, YT_DLP.player.Hotkeys.HotKeys.Default.I);
            HotkeyPreviewAssignment(HotkeyO, YT_DLP.player.Hotkeys.HotKeys.Default.O);
            HotkeyPreviewAssignment(HotkeyP, YT_DLP.player.Hotkeys.HotKeys.Default.P);
            HotkeyPreviewAssignment(HotkeyA, YT_DLP.player.Hotkeys.HotKeys.Default.A);
            HotkeyPreviewAssignment(HotkeyS, YT_DLP.player.Hotkeys.HotKeys.Default.S);
            HotkeyPreviewAssignment(HotkeyD, YT_DLP.player.Hotkeys.HotKeys.Default.D);
            HotkeyPreviewAssignment(HotkeyF, YT_DLP.player.Hotkeys.HotKeys.Default.F);
            HotkeyPreviewAssignment(HotkeyG, YT_DLP.player.Hotkeys.HotKeys.Default.G);
            HotkeyPreviewAssignment(HotkeyH, YT_DLP.player.Hotkeys.HotKeys.Default.H);
            HotkeyPreviewAssignment(HotkeyJ, YT_DLP.player.Hotkeys.HotKeys.Default.J);
            HotkeyPreviewAssignment(HotkeyK, YT_DLP.player.Hotkeys.HotKeys.Default.K);
            HotkeyPreviewAssignment(HotkeyL, YT_DLP.player.Hotkeys.HotKeys.Default.L);
            HotkeyPreviewAssignment(HotkeyZ, YT_DLP.player.Hotkeys.HotKeys.Default.Z);
            HotkeyPreviewAssignment(HotkeyX, YT_DLP.player.Hotkeys.HotKeys.Default.X);
            HotkeyPreviewAssignment(HotkeyC, YT_DLP.player.Hotkeys.HotKeys.Default.C);
            HotkeyPreviewAssignment(HotkeyV, YT_DLP.player.Hotkeys.HotKeys.Default.V);
            HotkeyPreviewAssignment(HotkeyB, YT_DLP.player.Hotkeys.HotKeys.Default.B);
            HotkeyPreviewAssignment(HotkeyN, YT_DLP.player.Hotkeys.HotKeys.Default.N);
            HotkeyPreviewAssignment(HotkeyM, YT_DLP.player.Hotkeys.HotKeys.Default.M);
            HotkeyPreviewAssignment(HotkeyComma, YT_DLP.player.Hotkeys.HotKeys.Default.Comma);
            HotkeyPreviewAssignment(HotkeyPeriod, YT_DLP.player.Hotkeys.HotKeys.Default.Period);
            HotkeyPreviewAssignment(HotkeyForwardSlash, YT_DLP.player.Hotkeys.HotKeys.Default.ForwardSlash);
            HotkeyPreviewAssignment(Hotkey1, YT_DLP.player.Hotkeys.HotKeys.Default.K1);
            HotkeyPreviewAssignment(Hotkey2, YT_DLP.player.Hotkeys.HotKeys.Default.K2);
            HotkeyPreviewAssignment(Hotkey3, YT_DLP.player.Hotkeys.HotKeys.Default.K3);
            HotkeyPreviewAssignment(Hotkey4, YT_DLP.player.Hotkeys.HotKeys.Default.K4);
            HotkeyPreviewAssignment(Hotkey5, YT_DLP.player.Hotkeys.HotKeys.Default.K5);
            HotkeyPreviewAssignment(Hotkey6, YT_DLP.player.Hotkeys.HotKeys.Default.K6);
            HotkeyPreviewAssignment(Hotkey7, YT_DLP.player.Hotkeys.HotKeys.Default.K7);
            HotkeyPreviewAssignment(Hotkey8, YT_DLP.player.Hotkeys.HotKeys.Default.K8);
            HotkeyPreviewAssignment(Hotkey9, YT_DLP.player.Hotkeys.HotKeys.Default.K9);
            HotkeyPreviewAssignment(Hotkey0, YT_DLP.player.Hotkeys.HotKeys.Default.K0);
            HotkeyPreviewAssignment(HotkeyHome, YT_DLP.player.Hotkeys.HotKeys.Default.Home);
            HotkeyPreviewAssignment(HotkeyEnd, YT_DLP.player.Hotkeys.HotKeys.Default.End);
            HotkeyPreviewAssignment(HotkeyPgUp, YT_DLP.player.Hotkeys.HotKeys.Default.PageUp);
            HotkeyPreviewAssignment(HotkeyPgDown, YT_DLP.player.Hotkeys.HotKeys.Default.PageDown);
            HotkeyPreviewAssignment(HotkeyDelete, YT_DLP.player.Hotkeys.HotKeys.Default.Delete);
            HotkeyPreviewAssignment(HotkeySpace, YT_DLP.player.Hotkeys.HotKeys.Default.Space);
            HotkeyPreviewAssignment(HotkeyArrowLeft, YT_DLP.player.Hotkeys.HotKeys.Default.ArrowLeft);
            HotkeyPreviewAssignment(HotkeyArrowRight, YT_DLP.player.Hotkeys.HotKeys.Default.ArrowRight);
            HotkeyPreviewAssignment(HotkeyArrowUp, YT_DLP.player.Hotkeys.HotKeys.Default.ArrowUp);
            HotkeyPreviewAssignment(HotkeyArrowDown, YT_DLP.player.Hotkeys.HotKeys.Default.ArrowDown);
        }
    }
}
