"git status ‚ÌƒTƒ“ƒvƒ‹"

function global:Git-Status {
    
    #git options
    param(
        [switch]${_-s},
        [switch]${_--short},
        [switch]${_-b},
        [switch]${_--branch},
        [switch]${_--show-stash},
        [ValidateSet("version", "dummy", "dummy2")]${_--porcelain},
        [switch]${_--long},
        [switch]${_-v},
        [switch]${_--verbose},
        [ValidateSet("mode", "dummy", "dummy2")]${_-u},
        [ValidateSet("mode", "dummy", "dummy2")]${_--untracked-files},
        [ValidateSet("mode", "dummy", "dummy2")]${_--ignore-submodules},
        [switch]${_--ignored},
        [switch]${_-z},
        [ValidateSet("column", "dummy", "dummy2")]${_--column},
        [switch]${_--no-column},
        [switch]${_--ahead-behind},
        [switch]${_--no-ahead-behind},
        [switch]${_--renames},
        [switch]${_--no-renames},
        [ValidateSet("n", "dummy", "dummy2", "dummy2")]${_--find-renames},
        [switch]${_--no-lock-index},
        [switch]${_--lock-index}
    )
    #test
    ${arg--porcelain}

    #make command
    #base
    $_temp = $MyInvocation.MyCommand.Name.ToLower()
    $_expression = "git " + 
                    $_temp.Substring(
                        "git-".Length, 
                        $_temp.Length - "git-".Length)

    # add git options
    if(${_-s}){$_expression += " -s"}
    if(${_--short}){$_expression += " --short"}
    if(${_-b}){$_expression += " -b"}
    if(${_--branch}){$_expression += " --branch"}
    if(${_--show-stash}){$_expression += " --show-stash"}
    if(${_--porcelain} -ne $null){$_expression += " --porcelain=" + ${_--porcelain}}
    if(${_--long}){$_expression += " --long"}
    if(${_-v}){$_expression += " -v"}
    if(${_--verbose}){$_expression += " --verbose"}
    if(${_-u} -ne $null){$_expression += " -u=" + ${_-u}}
    if(${_--untracked-files} -ne $null){$_expression += " --untracked-files=" + ${_--untracked-files}}
    if(${_--ignore-submodules} -ne $null){$_expression += " --ignore-submodules=" + ${_--ignore-submodules}}
    if(${_--ignored}){$_expression += " --ignored"}
    if(${_-z}){$_expression += " -z"}
    if(${_--column} -ne $null){$_expression += " --column=" + ${_--column}}
    if(${_--no-column}){$_expression += " --no-column"}
    if(${_--ahead-behind}){$_expression += " --ahead-behind"}
    if(${_--no-ahead-behind}){$_expression += " --no-ahead-behind"}
    if(${_--renames}){$_expression += " --renames"}
    if(${_--no-renames}){$_expression += " --no-renames"}
    if(${_--find-renames} -ne $null){$_expression += " --find-renames=" + ${_--find-renames}}
    if(${_--no-lock-index}){$_expression += " --no-lock-index"}
    if(${_--lock-index}){$_expression += " --lock-index"}

    #invoke command
    "execute : " + $_expression

    #$_expression = $_expression.Trim()
    #Invoke-Expression -Command $_expression
    
}