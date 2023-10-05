using System.Runtime.InteropServices;
using System;

class Program
{
	[DllImportAttribute("Kernel32.dll", CharSet=CharSet.Auto, SetLastError = true, ExactSpelling = false)]
	public static extern bool IsDebuggerPresent();
	[DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
	
	private const int SW_SHOWNORMAL = 1;
	
	public static void Main(string[] args)
    {
		bool debugPresent = IsDebuggerPresent();
		if (!debugPresent)
		{
			Console.WriteLine("Debugger Not Present");
			IntPtr execNotepad = ShellExecute(IntPtr.Zero, "open", "C:\\Windows\\System32\\notepad.exe", null, null, SW_SHOWNORMAL);
			if (execNotepad.ToInt32() <= 32)
			{
				Console.WriteLine("Operation Failed");
			}
		}
		else
		{
			Console.WriteLine("Debugger Present");
			return;
		}
    }
}