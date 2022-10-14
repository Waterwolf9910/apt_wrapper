# apt_wrapper
An executable that runs apt update and apt upgrade bi-daily

# Installation
Grab the executable from the releases tab and put it in /bin/
In order for the wrapper to start when the computer starts, copy
the .service file to /etc/systemd/system/ and run systemctl enable apt_wrapper
