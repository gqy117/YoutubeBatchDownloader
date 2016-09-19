Set ThunderAgent = CreateObject("ThunderAgent.Agent")
$ListVideo:{Call ThunderAgent.AddTask("$it.DownloadUrl$","$it.FileNameWithPrefix$","","","",1,0,10)
}$
Call ThunderAgent.CommitTasks()