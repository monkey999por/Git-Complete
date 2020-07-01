
#link href = https://qiita.com/heignamerican/items/a81a1f4de3e34b28d836
Set-Location -Path (Split-Path -Parent ($MyInvocation.MyCommand.Source))


#get git command list all
#�p�X�̉���git�̃w���v�t�@�C����"git-command.html"�̌`���œ����Ă�̂ŁA"command"�ɐ��`���ďo��

<#
�擾�����R�}���h���X�g�̒��ŁA���L�̓R�}���h�Ƃ��ĔF������Ȃ��B
�i�w���v�t�@�C��(git-command.html)�͕K�������ł͂Ȃ������B�j

bisect-lk2009
credential-cache--daemon
credential-cache
mergetool--lib
parse-remote
remote-helpers
shell
tools
#>
$help_file_dir = "C:\Program Files\Git\mingw64\share\doc\git-doc"
$hashTable =@{}
<#
$xml = "<?xml version='1.0' encoding='UTF-8' ?>"
$xml += "<command_list>"
#>
foreach ($item in $(Get-ChildItem -Path $help_file_dir )) {
    if (($item.Name -match "git`-") -and (
        ($item.Name -ne "git-bisect-lk2009.html") -and
        ($item.Name -ne "git-credential-cache--daemon.html") -and
        ($item.Name -ne "git-credential-cache.html") -and
        ($item.Name -ne "git-mergetool--lib.html") -and
        ($item.Name -ne "git-parse-remote.html") -and
        ($item.Name -ne "git-remote-helpers.html") -and
        ($item.Name -ne "git-shell.html") -and
        ($item.Name -ne "git-tools.html") -and
        ($item.Name -ne "git-sh-i18n.html") -and
        ($item.Name -ne "git-sh-setup.html")
        ))
    {
        $hashTable.Add("$git_command","$($help_file_dir + "\" + $item.Name)")
<#        
        #git help��html�̈ꗗ -> ��������I�v�V�����̈ꗗ���擾����
        $help_file = $help_file_dir + "\" + $item.Name
        $git_command = $item.Name.Substring(4, $($item.Name.IndexOf(".html")) - 4)
        $xml += "<command name=`"$git_command`">"
            $xml += "<options>"
                $xml += "<help_file>$($help_file_dir + "\" + $item.Name)</help_file>"
                $xml += "<option name=`"-help`">"
                    $xml += "<description>{option1}</description>"
                $xml += "</option>"
            $xml += "</options>"
        $xml += "</command>"
#>
    }
}
<#
#git command list ��xml�o��
$xml += "</command_list>"
$xml = [xml]$xml
$xml.Save("C:\develop\Project_Git-Complete\Git-Complete\out\git_command_object.xml")
#>

<#
git��help�t�@�C����xml�ǂݍ��݂ɂ���
��̂Ƃ���link�^�O��meta�^�O�i��s�ŏ�����Ă��j�̏I���̃X���b�V�����Ȃ��̂����߂炵��
""
#>




