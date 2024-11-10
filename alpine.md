# Host
For this part of the project, I want to use Alpine Linux.  Just to try it out. 

## Alpine WSL
On first startup set your username and password.  
```
Enter new UNIX username: <user>
New password:
Retype new password:
```
Alpine has doas instead of sudo.  Install it.     
```
su root
apk add doas
```
Next add our user to the 'wheel' group (which allows execution of doas commands - similar to the sudo group in Deb).  Show your groups.  
```
adduser <user> wheel
groups <user>
```
Lastly, ensure the wheel group has permission to run doas by setting the config.   
```
vi /etc/doas.d/doas.conf
permit :wheel as root
:wq
```
### WSL Bug
There seems to be a problem with the WSL Alpine image when configuring doas, resulting in 'authorization failure' messages being issued.  
A temporary work-around is to set the wheel group as nopass to doas.  
```
vi /etc/doas.d/doas.conf
permit nopass :wheel as root
:wq
```
### Configure Alpine Environment
Update alpine.
```
doas apk update
doas apk upgrade
```
I prefer the Bash shell, see if it exists.  
```
cat /etc/shells
```
If not then add it.  
```
doas apk add bash
doas apk add bash-doc
doas apk add bash-completion
```
Then slightly alter the shell setting of your user to use bash on login. 
```
doas vi /etc/passwd
<user>:x:1000:1000:User.Name:/home/<usewr>:/bin/bash
```
Login again and see if it is true.  Use the Process Status command as the most reliable method.  
```
echo $SHELL
ps
```
You may want some aliases in your bash environment.  Most commonly, the faster list commands or python short name.  Create a .bashrc file, as this is executed for every non-login shell.  
```
cd ~
vi .bashrc
alias ll='ls -lrt'
:wq
```
If you need to set variables or spawn a process shell and want variables to be inherited by them, create the .profile as the single place to set them.  

When using Bash only you can use .bash_profile which is always executed first in Bash.  But if the .bash_profile does not exist the processing falls through to using .profile, making it the most common way to define these variables in a multi-shell environment.   

In the example below, we take the Deb convention of also executing .bashrc first if we are using that shell.
```
vi .profile
# if running bash
if [ -n "$BASH_VERSION" ]; then
    # include .bashrc if it exists
    if [ -f "$HOME/.bashrc" ]; then
        . "$HOME/.bashrc"
    fi
fi

# set PATH so it includes user's private bin if it exists
if [ -d "$HOME/bin" ] ; then
    PATH="$HOME/bin:$PATH"
fi

# set PATH so it includes user's private .local bin if it exists
if [ -d "$HOME/.local/bin" ] ; then
    PATH="$HOME/.local/bin:$PATH"
fi
:wq
```
Once you are happy with the environment, install some fundamental tools to get started.  
```
doas apk add curl
doas apk add git
doas apk add openssh-keygen
doas apk add openssh-client
```