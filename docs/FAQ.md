---
layout: default
show_blog: false
---
# FAQ

The Corionis Service Manager, or CSM, is fairly self-explanatory and easy
to use for the target audience. It is intended for those who wish to 
monitor and/or manage a subset of Windows services.

 1. What privileges are required to run CSM?
    > To manage services, e.g. start and stop them, Administrator privileges are required, 
      see #2. CSM may be executed without Administrator privileges to monitor services 
      but the management controls are disabled.
 2. How is CSM executed?
    > The CSM installer and application create and manage a Windows Task
      Scheduler task. An "At log on" trigger is enabled/disabled depending
      on the setting on the CSM Options tab. It is initially enabled. The 
      "Corionis Service Manager Task" shortcut may be used to execute CSM
      manually and bypass the UAC warning.
 3. What if CSM does not start at login the first time?
    > If CSM is installed on a Windows Server platform when logged-in as Administrator
      but is not executed when the installation is complete the Windows Task Scheduler
      task may not be created.<br/>
      *Solution*: Run CSM "As Administrator", goto the Options tab, ensure the 
      "Start at login" option is checked, then click Save.
 4. Where is CSM installed?
    > Wherever the user selected during installation, by default CSM is installed in:<br/>
      C:\Users\\[*user*]\AppData\Local\Corionis Service Manager\ 
 5. What is in the Corionis Service Manager "Start" button group?
    > * **Check for Updates** -- Manually check for CSM updates.
    > * **Corionis Service Manager Task** -- Executes the Task Scheduler task 'As Administrator' bypassing the UAC prompt. 
    > * **Corionis Service Manager** -- Executes the CSM program directly. Right-click and 'Run as Administrator' to avoid the UAC.
    > * **Uninstall Corionis Service Manager** -- Completely removes CSM.
 6. Is the Windows Task Scheduler task removed during uninstall?
    > Yes. An uninstall removes CSM with an option to remove all related elements including it's JSON 
      configuration file and any log file.
 7. Why doesn't CSM have a Restart button?
    > CSM cannot accurately "know" when a service has finished its shutdown
      procedures and completely stopped. So knowing when it is safe to
      start the service again is not really possible and left up to the user.
 8. How does the updater work?
    > CSM includes an optional updater. It may be executed using the "Check for Updates" shortcut, or by
      selecting Help then Check for Updates in CSM. When the updater dialog is displayed there is an Options link
      where automated checking can be enabled for daily, weekly or monthly checks.
 9. How can the physical log file be emptied?
    > In CSM goto the Log tab, click Clear, then click Save. Additionally the
      log file can be deleted.
10. Where is the log file?
    > In the installation directory, see #4.
