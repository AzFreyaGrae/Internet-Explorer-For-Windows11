using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace Internet_Explorer
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr oldValue);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr oldValue);

        public Form1()
        {
            InitializeComponent();
            System32ieframedllbak();
            progressBar1.Minimum = 0; //设置进度条最小值
            progressBar1.Maximum = 5; //设置进度条最大值
            progressBar1.Value = 0; //初始值0
        }
        
        // 还原按钮
        private void Restore1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0; //初始值0
            button1.Enabled = false;
            Restore1.Enabled = false;
            
            // 创建一个 BackgroundWorker 实例
            BackgroundWorker bw = new BackgroundWorker
            {
                // 设置 BackgroundWorker 可以报告进度和支持异步取消操作
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            // 添加 DoWork 事件处理程序，其中包含要在后台执行的操作
            bw.DoWork += (sender1, e1) =>
            {
                StartExplorer(); // OK - 关闭进程并重启资源管理器
                bw.ReportProgress(1, "关闭Edge浏览器进程并重启Windows资源管理器...");
                System.Threading.Thread.Sleep(1000); // 延时1秒

                Admin_Sys(); // OK - 修改安全属性 Sys
                bw.ReportProgress(2, "重新设置System32目录中相关文件属性...");
                System.Threading.Thread.Sleep(1000); // 延时1秒

                Res_sysWOW64(); // OK - 还原sysWOW64
                bw.ReportProgress(3, "设置System32目录中相关文件...");
                System.Threading.Thread.Sleep(1000); // 延时1秒

                Res_System32(); // OK - 还原System32
                bw.ReportProgress(4, "设置SysWOW64目录中相关文件...");
                System.Threading.Thread.Sleep(1000); // 延时1秒

                bw.ReportProgress(5, "请手动删除Internet Explorer浏览器快捷方式...");
                System.Threading.Thread.Sleep(1000); // 延时1秒
                MessageBox.Show(" - 还原已完成！\n - 如果提示错误请点击“功能选项” - “重启资源管理器”然后重新还原。", "Restore :Internet_Explorer");
                button1.Enabled = true;
                Restore1.Enabled = true;
            };

            // 添加 ProgressChanged 事件处理程序，其中包含要在报告进度时执行的操作
            bw.ProgressChanged += (sender2, e2) =>
            {
                progressBar1.Value = e2.ProgressPercentage;
                label4.Text = e2.UserState.ToString();
            };

            // 启动 BackgroundWorker
            bw.RunWorkerAsync();
        }

        // 修复按钮
        private void Repair1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0; //初始值0
            button1.Enabled = false;
            Repair1.Enabled = false;

            // 创建一个 BackgroundWorker 实例
            BackgroundWorker bw = new BackgroundWorker
            {
                // 设置 BackgroundWorker 可以报告进度和支持异步取消操作
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            // 添加 DoWork 事件处理程序，其中包含要在后台执行的操作
            bw.DoWork += (sender1, e1) =>
            {
                StartExplorer(); // OK - 关闭进程并重启资源管理器
                bw.ReportProgress(1, "关闭Edge浏览器进程并重启Windows资源管理器...");
                System.Threading.Thread.Sleep(1000); // 延时1秒

                Admin_Sys(); // OK - 修改安全属性 Sys
                bw.ReportProgress(2, "重新设置System32目录中相关文件属性...");
                System.Threading.Thread.Sleep(1000); // 延时1秒

                Backup_System32(); // OK - 备份 & 替换 system32
                bw.ReportProgress(3, "设置System32目录中相关文件...");
                System.Threading.Thread.Sleep(1000); // 延时1秒

                Backup_sysWOW64();  //OK - 备份 & 替换 sysWOW64
                bw.ReportProgress(4, "设置SysWOW64目录中相关文件...");
                System.Threading.Thread.Sleep(1000); // 延时1秒

                Internet_Explorer_Link(); //OK - 创建Internet_Explorer浏览器快捷方式
                bw.ReportProgress(5, "创建Internet Explorer浏览器快捷方式...");
                System.Threading.Thread.Sleep(1000); // 延时1秒
                MessageBox.Show(" - 修复已完成！\n - 如果提示错误请点击“功能选项” - “重启资源管理器”然后重新修复。", "Repair :Internet_Explorer");

            };

            // 添加 ProgressChanged 事件处理程序，其中包含要在报告进度时执行的操作
            bw.ProgressChanged += (sender2, e2) =>
            {
                progressBar1.Value = e2.ProgressPercentage;
                label4.Text = e2.UserState.ToString();
            };

            // 启动 BackgroundWorker
            bw.RunWorkerAsync();
        }

        // 修改安全属性 (1/2)
        private void Admin_Sys()
        {
            IntPtr ptr = IntPtr.Zero;

            // 关闭64位文件系统的操作转向
            Wow64DisableWow64FsRedirection(ref ptr);

            // 执行命令行命令
            ExecuteCommand("takeown /F %SystemRoot%\\System32\\ieframe.dll");
            ExecuteCommand("icacls %SystemRoot%\\System32\\ieframe.dll /grant Everyone:F");
            ExecuteCommand("icacls %SystemRoot%\\System32\\ieframe.dll /setowner Everyone");

            ExecuteCommand("takeown /F %SystemRoot%\\SysWOW64\\ieframe.dll");
            ExecuteCommand("icacls %SystemRoot%\\SysWOW64\\ieframe.dll /grant Everyone:F");
            ExecuteCommand("icacls %SystemRoot%\\SysWOW64\\ieframe.dll /setowner Everyone");

            ExecuteCommand("takeown /F %SystemRoot%\\System32\\inetcpl.cpl");
            ExecuteCommand("icacls %SystemRoot%\\System32\\inetcpl.cpl /grant Everyone:F");
            ExecuteCommand("icacls %SystemRoot%\\System32\\inetcpl.cpl /setowner Everyone");

            ExecuteCommand("takeown /F %SystemRoot%\\SysWOW64\\inetcpl.cpl");
            ExecuteCommand("icacls %SystemRoot%\\SysWOW64\\inetcpl.cpl /grant Everyone:F");
            ExecuteCommand("icacls %SystemRoot%\\SysWOW64\\inetcpl.cpl /setowner Everyone");

            // 开启64位文件系统的操作转向
            Wow64RevertWow64FsRedirection(ptr);
        }

        // 修改安全属性 (2/2)
        static void ExecuteCommand(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + command;
            process.StartInfo.CreateNoWindow = true;  // 不创建命令行窗口
            process.StartInfo.UseShellExecute = false;  // 不使用操作系统外壳程序启动进程
            process.StartInfo.RedirectStandardOutput = true;  // 重定向标准输出流
            process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);  // 处理输出数据
            process.Start();
            process.BeginOutputReadLine();  // 异步读取输出数据
            process.WaitForExit();
        }
        
        // 还原文件 sysWOW64
        private void Res_sysWOW64()
        {
            string sysWOW64Path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            string ieframeBackupFilePath = Path.Combine(sysWOW64Path, "ieframe.dll.backup");
            string inetcplBackupFilePath = Path.Combine(sysWOW64Path, "inetcpl.cpl.backup");

            try
            {
                // 复制 ieframe.dll.backup 到 ieframe.dll
                if (System.IO.File.Exists(ieframeBackupFilePath))
                {
                    string ieframeFilePath = Path.Combine(sysWOW64Path, "ieframe.dll");
                    System.IO.File.Copy(ieframeBackupFilePath, ieframeFilePath, true);
                }
                else
                {
                    MessageBox.Show("找不到 ieframe.dll.backup 文件！");
                    label4.Text = "找不到 ieframe.dll.backup 文件！";
                    return;
                }

                // 复制 inetcpl.cpl.backup 到 inetcpl.cpl
                if (System.IO.File.Exists(inetcplBackupFilePath))
                {
                    string inetcplFilePath = Path.Combine(sysWOW64Path, "inetcpl.cpl");
                    System.IO.File.Copy(inetcplBackupFilePath, inetcplFilePath, true);
                    label4.Text = "SysWOW64 - 成功！";
                }
                else
                {
                    MessageBox.Show("找不到 inetcpl.cpl.backup 文件！");
                    label4.Text = "找不到 inetcpl.cpl.backup 文件！";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件复制失败：" + ex.Message);
            }
        }
        
        // 还原文件 System32
        private void Res_System32()
        {
            string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string ieframeBackupFilePath = Path.Combine(system32Path, "ieframe.dll.backup");
            string inetcplBackupFilePath = Path.Combine(system32Path, "inetcpl.cpl.backup");

            IntPtr oldValue = IntPtr.Zero;
            try
            {
                // 禁用文件系统重定向
                Wow64DisableWow64FsRedirection(ref oldValue);

                // 还原 ieframe.dll.backup 到 ieframe.dll
                if (System.IO.File.Exists(ieframeBackupFilePath))
                {
                    string ieframeFilePath = Path.Combine(system32Path, "ieframe.dll");
                    System.IO.File.Copy(ieframeBackupFilePath, ieframeFilePath, true);
                }
                else
                {
                    MessageBox.Show("找不到 ieframe.dll.backup 文件！");
                    label4.Text = "找不到 ieframe.dll.backup 文件！";
                    return;
                }

                // 还原 inetcpl.cpl.backup 到 inetcpl.cpl
                if (System.IO.File.Exists(inetcplBackupFilePath))
                {
                    string inetcplFilePath = Path.Combine(system32Path, "inetcpl.cpl");
                    System.IO.File.Copy(inetcplBackupFilePath, inetcplFilePath, true);
                    label4.Text = "system32 - 成功！";
                }
                else
                {
                    MessageBox.Show("找不到 inetcpl.cpl.backup 文件！");
                    label4.Text = "找不到 inetcpl.cpl.backup 文件！";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件复制失败：" + ex.Message);
            }
            finally
            {
                // 恢复文件系统重定向
                Wow64RevertWow64FsRedirection(oldValue);
            }
        }

        // 替换 System32 的文件 (1/3)
        private void Replace_System32()
        {
            string system32Path = GetSystem32Path();
            string ieframeFile = "ieframe.dll";
            string ieframeResourcePath = "Internet_Explorer.Resources.System32.ieframe.dll";
            string inetcplFile = "inetcpl.cpl";
            string inetcplResourcePath = "Internet_Explorer.Resources.System32.inetcpl.cpl";

            // 从内嵌资源中读取替换文件的字节数据
            byte[] ieframeBytes = GetEmbeddedResourceBytes(ieframeResourcePath);
            byte[] inetcplBytes = GetEmbeddedResourceBytes(inetcplResourcePath);

            // 将内嵌资源中的文件替换到System32目录
            string ieframePath = Path.Combine(system32Path, ieframeFile);
            string inetcplPath = Path.Combine(system32Path, inetcplFile);

            try
            {
                using (FileStream fileStream = new FileStream(ieframePath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(ieframeBytes, 0, ieframeBytes.Length);
                }

                using (FileStream fileStream = new FileStream(inetcplPath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(inetcplBytes, 0, inetcplBytes.Length);
                }

                MessageBox.Show("成功替换文件：" + ieframeFile + " 和 " + inetcplFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("替换文件时发生错误：" + ex.Message);
            }
        }

        // 替换 System32 的文件 (2/3)
        private string GetSystem32Path()
        {
            string windowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string system32Path = Path.Combine(windowsPath, "System32");

            if (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
            {
                // 如果是64位操作系统且当前进程是32位，则使用Sysnative目录
                system32Path = Path.Combine(windowsPath, "Sysnative");
            }

            return system32Path;
        }

        // 替换 System32 的文件 (3/3)
        private byte[] GetEmbeddedResourceBytes(string resourcePath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new Exception("无法找到内嵌资源：" + resourcePath);
                }

                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        
        // 备份 System32 的文件
        private void Backup_System32()
        {
            string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string ieframeFile = "ieframe.dll";
            string inetcplFile = "inetcpl.cpl";
            string backupExtension = ".backup";

            IntPtr oldValue = IntPtr.Zero;
            bool isWow64FsRedirectionDisabled = Wow64DisableWow64FsRedirection(ref oldValue);

            string ieframePath = Path.Combine(system32Path, ieframeFile);
            string inetcplPath = Path.Combine(system32Path, inetcplFile);

            if (System.IO.File.Exists(ieframePath))
            {
                string ieframeBackupPath = ieframePath + backupExtension;
                if (System.IO.File.Exists(ieframeBackupPath))
                {
                    MessageBox.Show("已存在备份文件：" + ieframeBackupPath);
                }
                else
                {
                    System.IO.File.Copy(ieframePath, ieframeBackupPath, true);
                    MessageBox.Show("成功备份文件：" + ieframeFile);
                }
            }
            else
            {
                MessageBox.Show("文件不存在：" + ieframeFile);
            }

            if (System.IO.File.Exists(inetcplPath))
            {
                string inetcplBackupPath = inetcplPath + backupExtension;
                if (System.IO.File.Exists(inetcplBackupPath))
                {
                    MessageBox.Show("已存在备份文件：" + inetcplBackupPath);
                    Replace_System32();
                }
                else
                {
                    System.IO.File.Copy(inetcplPath, inetcplBackupPath, true);
                    MessageBox.Show("成功备份文件：" + inetcplFile);
                    Replace_System32();
                }
            }
            else
            {
                MessageBox.Show("文件不存在：" + inetcplFile);
            }

            if (isWow64FsRedirectionDisabled)
            {
                Wow64RevertWow64FsRedirection(oldValue);
            }
        }
        
        // 替换 sysWOW64 的文件
        private void Replace_sysWOW64()
        {
            string sysWOW64Path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);

            try
            {
                // 获取当前程序集中嵌入的资源
                Assembly assembly = Assembly.GetExecutingAssembly();

                // 复制 ieframe.dll
                string firstResourceName = "Internet_Explorer.Resources.SysWOW64.ieframe.dll";
                string firstDestinationFilePath = Path.Combine(sysWOW64Path, "ieframe.dll");

                using (Stream firstResourceStream = assembly.GetManifestResourceStream(firstResourceName))
                {
                    if (firstResourceStream != null)
                    {
                        using (FileStream firstFileStream = System.IO.File.Create(firstDestinationFilePath))
                        {
                            firstResourceStream.CopyTo(firstFileStream);
                        }
                    }
                    else
                    {
                        MessageBox.Show("找不到ieframe.dll文件资源！");
                        label4.Text = "找不到ieframe.dll文件资源！";
                    }
                }

                // 复制 inetcpl.cpl
                string secondResourceName = "Internet_Explorer.Resources.SysWOW64.inetcpl.cpl";
                string secondDestinationFilePath = Path.Combine(sysWOW64Path, "inetcpl.cpl");

                using (Stream secondResourceStream = assembly.GetManifestResourceStream(secondResourceName))
                {
                    if (secondResourceStream != null)
                    {
                        using (FileStream secondFileStream = System.IO.File.Create(secondDestinationFilePath))
                        {
                            secondResourceStream.CopyTo(secondFileStream);
                        }
                        label4.Text = "SysWOW64 - 成功！";
                    }
                    else
                    {
                        MessageBox.Show("找不到inetcpl.cpl文件资源！");
                        label4.Text = "找不到inetcpl.cpl文件资源！";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件复制失败：" + ex.Message);
            }
        }
        
        // 备份（1/3） sysWOW64 目录下的文件 ieframe.dll inetcpl.cpl
        private void Backup_sysWOW64()
        {
            string sysWOW64Path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            
            string sysWOW64SourcePath0 = Path.Combine(sysWOW64Path, "ieframe.dll");
            string sysWOW64BackupPath0 = Path.Combine(sysWOW64Path, "ieframe.dll.Backup");
            
            string sysWOW64SourcePath1 = Path.Combine(sysWOW64Path, "inetcpl.cpl");
            string sysWOW64BackupPath1 = Path.Combine(sysWOW64Path, "inetcpl.cpl.Backup");
            
            try
            {
                // 备份 SysWOW64 目录下的 ieframe.dll 文件
                BackupFile(sysWOW64SourcePath0, sysWOW64BackupPath0);
                
                // 备份 SysWOW64 目录下的 inetcpl.cpl 文件
                BackupFile(sysWOW64SourcePath1, sysWOW64BackupPath1);

                label4.Text = "SysWOW64 备份完成！";
                Replace_sysWOW64(); //替换 sysWOW64 的文件
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("备份失败：" + ex.Message);
            }
        }

        // 备份（2/3） sysWOW64 目录下的文件 ieframe.dll inetcpl.cpl
        private void BackupFile(string sourcePath, string backupPath)
        {
            // 检查源文件是否存在
            if (System.IO.File.Exists(sourcePath))
            {
                // 检查备份文件是否已经存在
                if (!System.IO.File.Exists(backupPath))
                {
                    // 使用管理员权限运行命令行
                    RunCommandAsAdmin($"copy \"{sourcePath}\" \"{backupPath}\"", out string output);

                    //MessageBox.Show(output);
                    MessageBox.Show($"备份文件 {backupPath} 成功。");
                }
                else
                {
                    MessageBox.Show($"备份文件 {backupPath} 已存在，无需备份。");
                }
            }
            else
            {
                MessageBox.Show($"源文件 {sourcePath} 不存在。");
            }
        }

        // 备份（3/3） sysWOW64 目录下的文件 ieframe.dll inetcpl.cpl
        private void RunCommandAsAdmin(string command, out string output)
        {
            // 创建一个新的进程对象
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Verb = "runas";  // 以管理员权限运行
            process.StartInfo.Arguments = "/c " + command;  // 执行命令
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            // 启动进程并等待完成
            process.Start();
            process.WaitForExit();

            // 读取输出结果
            output = process.StandardOutput.ReadToEnd();
        }

        // 重启资源管理器
        private void StartExplorer()
        {
            // 结束 msedge.exe 进程
            Process[] edgeProcesses = Process.GetProcessesByName("msedge");
            foreach (Process process in edgeProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 结束 msedge.exe 进程
            Process[] ScriptedSandBox64Processes = Process.GetProcessesByName("ScriptedSandbox64");
            foreach (Process process in ScriptedSandBox64Processes)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 结束 iexplore.exe 进程
            Process[] ieProcesses = Process.GetProcessesByName("iexplore");
            foreach (Process process in ieProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 结束所有 RuntimeBroker.exe 进程
            Process[] runtimeBrokerProcesses = Process.GetProcessesByName("RuntimeBroker");
            foreach (Process process in runtimeBrokerProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 等待一段时间，让进程关闭
            Thread.Sleep(2000);

            // 再次检查并结束所有 RuntimeBroker.exe 进程
            runtimeBrokerProcesses = Process.GetProcessesByName("RuntimeBroker");
            foreach (Process process in runtimeBrokerProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 结束资源管理器进程
            Process[] explorerProcesses = Process.GetProcessesByName("explorer");
            foreach (Process process in explorerProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 启动资源管理器
            //Process.Start("explorer.exe");
        }

        // 重启资源管理器 - 菜单
        private void StartExplorerA()
        {
            button1.Enabled = false;
            Restore1.Enabled = false;
            Repair1.Enabled = false;
            // 结束 msedge.exe 进程
            Process[] edgeProcesses = Process.GetProcessesByName("msedge");
            foreach (Process process in edgeProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 结束 msedge.exe 进程
            Process[] ScriptedSandBox64Processes = Process.GetProcessesByName("ScriptedSandbox64");
            foreach (Process process in ScriptedSandBox64Processes)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 结束 iexplore.exe 进程
            Process[] ieProcesses = Process.GetProcessesByName("iexplore");
            foreach (Process process in ieProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 结束所有 RuntimeBroker.exe 进程
            Process[] runtimeBrokerProcesses = Process.GetProcessesByName("RuntimeBroker");
            foreach (Process process in runtimeBrokerProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 等待一段时间，让进程关闭
            Thread.Sleep(2000);

            // 再次检查并结束所有 RuntimeBroker.exe 进程
            runtimeBrokerProcesses = Process.GetProcessesByName("RuntimeBroker");
            foreach (Process process in runtimeBrokerProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            // 结束资源管理器进程
            Process[] explorerProcesses = Process.GetProcessesByName("explorer");
            foreach (Process process in explorerProcesses)
            {
                if (!process.HasExited)
                {
                    TerminateProcess(process);
                }
            }

            button1.Enabled = true;
            Restore1.Enabled = true;
            Repair1.Enabled = true;

            // 启动资源管理器
            //Process.Start("explorer.exe");
        }

        // 结束进程
        private void TerminateProcess(Process process)
        {
            try
            {
                process.Kill();
                process.WaitForExit();
            }
            catch (Win32Exception ex)
            {
                // 输出异常信息
                Console.WriteLine($"Failed to terminate process: {process.ProcessName}. Error: {ex.Message}");
            }
        }

        // 创建 Internet Explorer 快捷方式
        private void Internet_Explorer_Link()
        {
            DialogResult result = MessageBox.Show("是否创建Internet Explorer 快捷方式？", "Internet Explorer 快捷方式", MessageBoxButtons.YesNo);

            // 根据用户的响应做出相应的处理
            if (result == DialogResult.Yes)
            {
                string programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                string internetExplorerPath = Path.Combine(programFilesPath, "Internet Explorer", "iexplore.exe");

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string shortcutPath = Path.Combine(desktopPath, "Internet Explorer.lnk");

                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

                shortcut.TargetPath = internetExplorerPath;
                shortcut.Save();

                button1.Enabled = true;
                Repair1.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                Repair1.Enabled = true;
            }
            
        }

        // 打开Sys32 ieframedll 备份位置
        private void 打开备份位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string backupFileName = "ieframe.dll.backup";

            IntPtr oldValue = IntPtr.Zero;
            bool isWow64FsRedirectionDisabled = Wow64DisableWow64FsRedirection(ref oldValue);

            string backupFilePath = Path.Combine(system32Path, backupFileName);

            if (System.IO.File.Exists(backupFilePath))
            {
                Process.Start("explorer.exe", "/select, " + backupFilePath);
            }
            else
            {
                MessageBox.Show("文件不存在：" + backupFileName, "Error");
            }

            if (isWow64FsRedirectionDisabled)
            {
                Wow64RevertWow64FsRedirection(oldValue);
            }
        }

        // 打开Sys64 ieframedll 备份位置
        private void 打开SysWOW64备份位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sysWOW64Path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            string bakFilePath = $"{sysWOW64Path}\\ieframe.dll.Backup";

            if (System.IO.File.Exists(bakFilePath))
            {
                Process.Start("explorer.exe", $"/select, \"{bakFilePath}\"");
            }
            else
            {
                MessageBox.Show("文件不存在：ieframe.dll.Backup","Error");
            }
        }

        // 打开Sys32 inetcpl.cpl 备份位置
        private void 打开Systme32Ieframedll备份位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string backupFileName = "inetcpl.cpl.backup";

            IntPtr oldValue = IntPtr.Zero;
            bool isWow64FsRedirectionDisabled = Wow64DisableWow64FsRedirection(ref oldValue);

            string backupFilePath = Path.Combine(system32Path, backupFileName);

            if (System.IO.File.Exists(backupFilePath))
            {
                Process.Start("explorer.exe", "/select, " + backupFilePath);
            }
            else
            {
                MessageBox.Show("文件不存在：" + backupFileName, "Error");
            }

            if (isWow64FsRedirectionDisabled)
            {
                Wow64RevertWow64FsRedirection(oldValue);
            }
        }

        // 打开Sys64 inetcpl.cpl 备份位置
        private void 打开SysWOW64Ieframedll备份位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sysWOW64Path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            string bakFilePath = $"{sysWOW64Path}\\inetcpl.cpl.Backup";

            if (System.IO.File.Exists(bakFilePath))
            {
                Process.Start("explorer.exe", $"/select, \"{bakFilePath}\"");
            }
            else
            {
                MessageBox.Show("文件不存在：inetcpl.cpl.Backup", "Error");
            }
        }

        // 打开 Internet 属性
        private void 打开IntelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("inetcpl.cpl");
            }
            catch (Exception ex)
            {
                Console.WriteLine("无法打开Internet属性界面：" + ex.Message);
            }
        }

        // 菜单 关于 - 软件
        private void 关于此软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" - 根据官网通知对 Internet Explorer 的支持已于 2022 年 6 月 15 日结束。 \n - 此软件将替换不支持的版本到以前支持的版本。 \n - 此软件不收费，无广告。" , "关于\"Internet Explorer\"");
        }

        // 菜单 关于 - 作者
        private void 关于作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" - 作者:Ae (FreyaGrace) \n - 这个也是因为批处理因为一些系统变量无法正常运行。 \n - 业余时间制作的一个C#程序。\n - 界面UI感觉有点丑..." , "作者\"FreyaGrace\"");
        }

        // 检查文件System32 ieframe 备份状态
        private void System32ieframedllbak()
        {
            string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string ieframeBackupFile = "ieframe.dll.backup";
            string inetcplBackupFile = "inetcpl.cpl.backup";

            IntPtr oldValue = IntPtr.Zero;
            bool isWow64FsRedirectionDisabled = Wow64DisableWow64FsRedirection(ref oldValue);

            bool ieframeExists = CheckFileExists(system32Path, ieframeBackupFile);
            bool inetcplExists = CheckFileExists(system32Path, inetcplBackupFile);

            if (ieframeExists)
            {
                //MessageBox.Show("System32 目录中存在文件：" + ieframeBackupFile);
            }
            else
            {
                //MessageBox.Show("System32 目录中不存在文件：" + ieframeBackupFile);
                label5.Text = "缺少备份文件ieframe.dll.backup...     ";
                label4.Text = "等待首次运行...               ";
                Restore1.Enabled = false;

            }

            if (inetcplExists)
            {
                //MessageBox.Show("System32 目录中存在文件：" + inetcplBackupFile);
                SysWOW64ieframedllbak();
            }
            else
            {
                //MessageBox.Show("System32 目录中不存在文件：" + inetcplBackupFile);
                label5.Text = "缺少备份文件inetcpl.cpl.backup...";
                label4.Text = "等待首次运行...";
                Restore1.Enabled = false;
            }

            if (isWow64FsRedirectionDisabled)
            {
                Wow64RevertWow64FsRedirection(oldValue);
            }
        }

        static bool CheckFileExists(string path, string fileName)
        {
            string filePath = Path.Combine(path, fileName);
            return System.IO.File.Exists(filePath);
        }

        // 检查文件SysWOW64 ieframe 备份状态
        private void SysWOW64ieframedllbak()
        {
            string sysWOW64Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SysWOW64");
            string filePath = Path.Combine(sysWOW64Path, "ieframe.dll.backup");

            bool fileExists = System.IO.File.Exists(filePath);

            if (fileExists)
            {
                SysWOW64inetcplcplbak();
            }
            else
            {
                label5.Text = "缺少备份文件ieframe.dll.backup...";
                label4.Text = "等待首次运行...";
                Restore1.Enabled = false;
            }
        }

        // 检查文件SysWOW64 inetcpl 备份状态
        private void SysWOW64inetcplcplbak()
        {
            string sysWOW64Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SysWOW64");
            string filePath = Path.Combine(sysWOW64Path, "inetcpl.cpl.backup");

            bool fileExists = System.IO.File.Exists(filePath);

            if (fileExists)
            {
                label5.Text = "还原可用，存在备份文件...";
                label4.Text = "等待替换或还原操作...";
                Restore1.Enabled = true;
            }
            else
            {
                label5.Text = "缺少备份文件inetcpl.cpl.backup...";
                label4.Text = "等待首次运行...";
                Restore1.Enabled = false;
            }
        }
        
        // 菜单 - 重启资源管理器
        private void 重启资源管理器ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartExplorerA();
        }

        // 切换备份 与 替换
        private void Button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0; //初始值0
            if (Repair1.Enabled)
            {
                Repair1.Enabled = false;
                Restore1.Visible = true;
                button1.BackgroundImage = Internet_Explorer.Properties.Resources.EDR;
                System32ieframedllbak();
            }
            else
            {
                Repair1.Enabled = true;
                Restore1.Visible = false;
                button1.BackgroundImage = Internet_Explorer.Properties.Resources.IER;
            }
            
        }
    }
}
