---
layout: default
show_blog: false
---
# FAQ

The Corionis Service Manager - CSM - is fairly self-explanatory and easy
to use for the target audience. It is intended for those who wish to 
monitor and/or manage a subset of Windows services.

 1. What privileges are required to run CSM?
    > To manage services, e.g. start/stop, requires Administrator privileges, 
      see 'How is CSM executed?'. CSM may be executed without Administrator
      privileges to monitor services but the management controls are disabled.
 2. How is CSM executed?
    > The CSM installer and application create and manage a Windows Task
      Scheduler task. An "At log on" trigger is enabled/disabled depending
      on the setting on the CSM Options tab. Is is initially enabled. The 
      Corionis Service Manager Task shortcut may be used to execute CSM
      manually and bypass the UAC warning.
 3. Where is CSM installed?
    > By default CSM is installed in: C:\Users\\[*user*]\AppData\Local\Corionis Service Manager\.
 4. What are the installed shortcuts on the Windows Start button?
    > * **Check for Updates** -- Manually check for CSM updates.
    > * **Corionis Service Manager Task** -- Executes the Task Scheduler task 'As Administrator' bypassing the UAC prompt. 
    > * **Corionis Service Manager** -- Executes the CSM program directly. Right-click and 'Run as Administrator' to avoid UAC.
    > * **Uninstall Corionis Service Manager** -- Completely removes CSM.
 5. Is the Windows Task Scheduler Task removed during uninstall?
    > Yes. An uninstall removes all CSM-related elements including it's JSON configuration file and any log file.
 6. Why doesn't CSM have a Restart button?
    > CSM cannot accurately "know" when a service has finished its shutdown
      procedures and completely stopped. So knowing when it is safe to
      start the service again is not really possible and left up to the user.
 7. How does the updater work?
    > CSM includes an optional updater. It may be executed using the **Check for Updates** shortcut, or by
      select Help, Check for Updates in CSM. When the updater dialog is displayed there is an Options link
      where automated checking can be enabled for daily, weekly or monthly checks.
