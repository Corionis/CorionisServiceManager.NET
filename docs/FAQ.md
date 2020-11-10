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
      on the setting on the Options tab. Is is initially enabled.

 3. Is the Windows Task Scheduler Task removed during uninstall?
    > Yes. An uninstall removes all CSM-related elements.

 4. Why doesn't CSM have a Restart button?
    > CSM cannot accurately "know" when a service has finished its shutdown
      procedures and completely stopped. So knowing when it is safe to
      start the service again is not really possible and left up to the user.
