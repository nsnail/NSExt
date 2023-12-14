# dot

[中](README.zh-CN.md) | **En**

Cross-platform, all-around utility set with a beautiful character interface-the Swiss Army knife

### Brief introduction

The dot is the one based on the one. NET 7, a cross-platform command-line tool, integrates more than 10 utilities that
program developers often use in their daily work, and is constantly increasing.

```
USAGE:
    dot [OPTIONS] <COMMAND>

OPTIONS:
    -h, --help       Prints help information
    -v, --version    Prints version information

COMMANDS:
    git                                      Git batch operation tool
    color                                    Screen coordinate color selection tool
    tran                                     Translation tools
    guid                                     GUID tool
    ip                                       IP tools
    json                                     Json tool
    pwd <password length> <generate type>    Random password generator
    rbom                                     Remove the uf8 bom of the file
    trim                                     Remove line breaks and spaces at the end of the file
    text                                     Text encoding tool
    time                                     Time synchronization tool
    tolf                                     Convert newline characters to LF
    get <url>                                Multithreaded download tool

```

### Some functional examples

- ##### Git batch management

When you have a clone and a lot of git repositories, use this command to pull their latest code all at once:

```
dot git -a "pull" d:\repos
```

![20221212212417](./assets/snapshots/20221212212417.png)

Similarly, you can execute any git commands on a bunch of git repositories in bulk:

```
dot git -a "config --get http.proxy" d:\repos
```

![20221212213957](./assets/snapshots/20221212213957.png)

- ##### High-precision time-clock synchronization

Supports parallel requests from multiple NTP clock servers, while removing the network communication duration to set the
precise synchronization of the native clocks with the NTP standard time:

```
dot time -k
```

![20221212214514](./assets/snapshots/20221212214514.png)

- ##### Text codec

Copy you need to view various codec text in the clipboard, and then enter the following command to view

```
dot text
```

![20221212214904](./assets/snapshots/20221212214904.png)

- ##### Multi-threading download tool

Support setting the block size, number of threads to replace the single thread wget tool:

```
dot get https://github.com/nsnail/dot/releases/download/v1.1.1/dot-v1.1.1-win-x64.7z
```

![20221212215259](./assets/snapshots/20221212215259.png)

- ##### Remove the blank at the end of the file

Remove excess spaces and line breaks in the tail of all files in the specified directory:

```
dot trim d:\repos
```

![20221212215853](./assets/snapshots/20221212215853.png)