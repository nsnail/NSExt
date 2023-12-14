# dot

[En](README.md) | **中**

跨平台的、具有美观字符界面的全能实用工具集 - 程序员的瑞士军刀

### 简介

dot 是一款基于.NET7，跨平台的命令行工具，集成10多种程序开发人员在日常工作常常用到的实用功能，并且还在不断增加。

```
USAGE:
    dot [OPTIONS] <COMMAND>

OPTIONS:
    -h, --help       Prints help information
    -v, --version    Prints version information

COMMANDS:
    git                                      Git批量操作工具
    color                                    屏幕坐标颜色选取工具
    tran                                     翻译工具
    guid                                     GUID工具
    ip                                       IP工具
    json                                     Json工具
    pwd <password length> <generate type>    随机密码生成器
    rbom                                     移除文件的uf8 bom
    trim                                     移除文件尾部换行和空格
    text                                     文本编码工具
    time                                     时间同步工具
    tolf                                     转换换行符为LF
    get <url>                                多线程下载工具

```

### 部分功能示例

- ##### Git批量管理

当你clone了大量的git仓库， 使用这条命令可以一次性拉取它们的最新代码：

```
dot git -a "pull" d:\repos
```

![20221212212417](./assets/snapshots/20221212212417.png)

类似地，你可以批量对一堆git仓库执行任何git命令：

```
dot git -a "config --get http.proxy" d:\repos
```

![20221212213957](./assets/snapshots/20221212213957.png)

- ##### 高精度时钟同步

支持多个NTP时钟服务器并行请求，同时除去网络通信时长以设置本机时钟与NTP标准时间精确同步：

```
dot time -k
```

![20221212214514](./assets/snapshots/20221212214514.png)

- ##### 文本编解码

复制你需要查看各种编解码的文本在剪贴板中，然后输入如下命令，即可查看

```
dot text
```

![20221212214904](./assets/snapshots/20221212214904.png)

- ##### 多线程下载工具

支持设置分块大小，线程数量，用以替代单线程的wget工具：

```
dot get https://github.com/nsnail/dot/releases/download/v1.1.1/dot-v1.1.1-win-x64.7z
```

![20221212215259](./assets/snapshots/20221212215259.png)

- ##### 移除文件末尾空白

移除指定目录下所有文件尾部多余的空格和换行符：

```
dot trim d:\repos
```

![20221212215853](./assets/snapshots/20221212215853.png)