/***************************/
/*  DEFAULT                */ 
/***************************/
#define iojZS_version				"1.18"
#define iojZS_no_check_dirs			"/_HDD/ /private/ /groups/ /nocheck/ /temp/ /request/nocheck/ /fonts/ /slosub/"
#define iojZS_no_mp3_symlink_dirs		"/GROUPS/ /mp3/.pre/"
#define iojZS_no_message_dirs			"/GROUPS/ /0day/ /0day/.pre/ /appz/.pre/ /bookware/.pre/ /divx/.pre/ /dvdr/.pre/ /ebook/.pre/ /games/.pre/ /mp3/.pre/ /pda/.pre/ /series/.pre/ /utils/.pre/ /vcd/.pre/ /xxx/.pre/"
#define iojZS_speedtest_dir			"/request/speedtest/"
#define iojZS_skip_ext				"jpg,jpeg,cue,txt,tcl,itcl,ini,cfg,m3u,avi,mpg,mpeg,vob"
#define iojZS_not_ext				"exe,diz,bat,cmd"
#define iojZS_skip_dir				"sample,covers,extra"
#define iojZS_allow_genre			"dance,trance,house,rock"
#define iojZS_skip_genre			"techno,trance,indie,lo-fi,noise"
#define iojZS_missing_file			".missing"
#define iojZS_bad_name_file			".bad"
#define iojZS_chmod_0byte_file			755
#define iojZS_chmod_symlink			777
#define iojZS_chmod_status			777
#define iojZS_total_display_users		10
#define iojZS_total_display_groups		1
#define iojZS_minimum_halfway_files		5
#define iojZS_logfile				"..\\logs\\iojZS.log"
#define iojZS_window_name			"ioFTPD::MessageWindow"
/***************************/
/*  OUTPUT CLiENT          */ 
/***************************/
#define iojZS_header				".----------=[ iojZS_v.%v ]=-------=[ Jeza ]=-------=[ (C) 2005 ]=-------.\n"
#define iojZS_skip_file				"| SKiPPED...: %-59.59f |\n"
#define iojZS_ok_file				"| OK........: %-59.59f |\n"
#define iojZS_bad_file				"| BAD.......: %-59.59f |\n"
#define iojZS_delete_reason			"| DELETED...: %-59.59s |\n"
#define iojZS_mp3_header			"|----------=[ iD3 iNFO ]=-------------------------------------------------|\n"
#define iojZS_stats_id3				"| ARTiST....: %-59.59A |\n" \
						"| ALBUM.....: %-59.59S |\n" \
						"| TiTLE.....: %-59.59D |\n" \
						"| GENRE.....: %-59.59X |\n" \
						"| YEAR......: %-59.59Y |\n"
#define iojZS_stats_bad_genre			"| BAD GENRE.: %-59.59X |\n"
#define iojZS_user_header			"|----------=[ UserTop ]=--------------------------------------------------|\n"
#define iojZS_stats_users			"| %3p.  %-24u   %10m   %3P %% %3f F  %5s kBps   |\n"
#define iojZS_group_header			"|----------=[ GroupTop ]=-------------------------------------------------|\n"
#define iojZS_stats_groups			"| %3p.  %-24g   %10b   %3Q %% %3c F  %5q kBps   |\n"
#define iojZS_progressmeter_footer		"'----------=[%b]=------------------------------=[ %3p/%-3t ]=--'\n"
#define iojZS_footer				"'-------------------------------------------------------------------------'\n"
#define iojZS_delete_sfv_reason			".sfv allready exist"
#define iojZS_delete_crc_reason			"CRC failed"
#define iojZS_delete_not_in_sfv_reason		"not in .sfv"
#define iojZS_delete_no_sfv_reason		"upload sfv first"
#define iojZS_delete_o_byte			"0 byte file uploaded"
#define iojZS_delete_miss_ext			"unknown file"
#define iojZS_delete_not_ext			"file not allowed"
#define iojZS_delete_speed_test			"speedtest"
#define iojZS_rescan_head			"-----------=[ iojZS_v.%v ]=-----------=[ Jeza ]=-----------=[ (C) 2005 ]=---------\n" \
						" Name                                                         file      sfv   Status\n"
#define iojZS_rescan_no_sfv			" Upload sfv First!                                                         \n"
#define iojZS_rescan_more_sfv			" More than 1 sfv Found!                                                    \n"
#define iojZS_rescan_file_not_in_sfv		" '%s' Not Found in sfv!                                                    \n"
#define iojZS_rescan_ok				"OK"
#define iojZS_rescan_fail			"FAIL"
#define iojZS_rescan_missing			"MiSSiNG"
#define iojZS_rescan_id3			"------------------------------------------------------------------------------------\n" \
						" ALBUM.....: %-59.59S  \n" \
						" GENRE.....: %-59.59X  \n" \
						" YEAR......: %-59.59Y  \n"
#define iojZS_rescan_total			"------------------------------------------------------------------------------------\n" \
						" TOTAL.....: %-59t     \n" \
						" OK........: %-59O     \n" \
						" FAiLED....: %-59H     \n" \
						" MiSSiNG...: %-59m     \n" \
						" SiZE......: %-59e     \n"
#define iojZS_rescan_foot			"------------------------------------------------------------------------------------\n"
/***************************/
/*  BARS                   */ 
/***************************/
#define iojZS_incomplete_link			"[iNCOMPLETE]-%r"
#define iojZS_incomplete_link_cd		"[iNCOMPLETE]-%d_(%c)"
#define iojZS_incmpl_bar			"]-[iNCOMPLETE]-[ %p%% ]-[%kFiLES of %tFiLE(s)]-[iNCOMPLETE]-["
#define iojZS_cmpl_bar				"]-[Complete %e in %tFiLE(s) ]-["
#define iojZS_mp3_incmpl_bar			"]-[iNCOMPLETE]-[ %p%% ]-[%kTRACK(s) of %tTRACK(s) @ %X - %Y]-[iNCOMPLETE]-["
#define iojZS_mp3_cmpl_bar			"]-[Complete %e in %tTRACK(s) @ %X - %Y]-["
#define iojZS_delete_bar			"]-[*"
#define iojZS_progressmeter_length	 	14
#define iojZS_progressmeter_filled_char 	'#'
#define iojZS_progressmeter_missing_char	'-'
#define iojZS_users_stats_file			"_%p__%u@%g_%m_%P%%_%fF_%skBps_"	//same cookies as in iojZS_stats_users
#define iojZS_delete_users_stats_file		"_*@*%*_"
/***************************/
/*  SYMLiNKS               */ 
/***************************/
#define iojZS_mp3_genre_dir			"d:\\test\\sort\\by.genre"
#define iojZS_mp3_year_dir			"d:\\test\\sort\\by.year"
#define iojZS_mp3_group_dir			"d:\\test\\sort\\by.group"
#define iojZS_mp3_group_artist			"d:\\test\\sort\\by.artist"
/***************************/
/*  .ioFTPD.message        */ 
/***************************/
#define iojZS_msg_head_release			"                                                                        \n" \
						"                                                                        \n" \
						"  RELEASE...: %R                                                        \n" \
						"                                                                        \n" \
						"  SiZE......: %e                                                        \n" \
						"  FiLES.....: %t                                                        \n" \
						"  SPEED.....: %J kBps                                                   \n" \
						"  RACE TiME.: %N                                                        \n" \
						"                                                                        \n"
#define iojZS_msg_mp3_info			"  MP3 iNFO..:                                                           \n" \
						"                                                                        \n" \
						"  ARTiST....: %-59.59A                                                  \n" \
						"  ALBUM.....: %-59.59S                                                  \n" \
						"  GENRE.....: %-59.59X                                                  \n" \
						"  YEAR......: %-59.59Y                                                  \n" \
						"                                                                        \n" \
						"                                                                        \n"
#define iojZS_msg_head_users			"                                USER-TOP                                \n" \
						" ---------------------------------------------------------------------- \n"
#define iojZS_msg_users				" %3p.  %-24u   %10m   %3P %% %3f F  %5s kBps                            \n"
#define iojZS_msg_head_groups			"                                                                        \n" \
						"                                GROUPTOP                                \n" \
						" ---------------------------------------------------------------------- \n"
#define iojZS_msg_groups			" %3p.  %-24g   %10b   %3Q %% %3c F  %5q kBps                            \n"
#define iojZS_msg_foot				"                                                                        \n"
/***************************/
/*  SCRiPT                 */ 
/***************************/
#define iojZS_rar_on_rls_complete		"c:\\Progra~1\\WinRar\\UnRAR.exe x -o+ %a\\*.rar d:\\play\\%h\\"
#define iojZS_zip_on_rls_complete		"unzip.exe -qqojC \"%a\\*.zip\" \"*\" -d \"d:\\play\\%h\\\""
#define iojZS_on_nfo_uploaded			"nfo.exe %i"
#define iojZS_on_sfv_uploaded			"sfv.exe %i"
#define iojZS_on_zip_uploaded			"unzip.exe -qqojC \"%i\" \"*\" -d \"d:\\play\\%h\\\""
/***************************/
/*  ENABLE                 */ 
/***************************/
#define iojZS_get_user_stats			true		//rank
#define iojZS_write_affils_stats		false		//will write USER/GROUP TOP to .ioFTPD.message
#define iojZS_check_files_when_race		false		//will check if all files exists that are loged to racefile. if true a litle slower files check
#define iojZS_create_bad_files			false		//true will create xxx.bad file [false will delete failed file]
#define iojZS_log_ioftpd			true		//write to ../logs/ioFTPD.log
#define iojZS_log_iojzs				false		//write to iojZS_logfile
#define iojZS_create_stats_files		false		//will create iojZS_users_stats_file file for each user
#define iojZS_check_ok_genre			false		//allowed only iojZS_allow_genre
#define iojZS_check_bad_genre			false		//not allowed if iojZS_skip_genre
#define iojZS_delete_bad_genre			true		//delete if any of iojZS_skip_genre or not iojZS_allow_genre
#define iojZS_run_rar_on_complete		false		//execute iojZS_rar_on_rls_complete
#define iojZS_run_zip_on_complete		false		//execute iojZS_zip_on_rls_complete
#define iojZS_run_nfo_on_upload			false		//execute iojZS_on_nfo_uploaded
#define iojZS_run_sfv_on_upload			false		//execute iojZS_on_sfv_uploaded
#define iojZS_run_zip_on_upload			false		//execute iojZS_on_zip_uploaded
#define iojZS_dont_wait_for_script		true		//printf("!detach 0\n");
#define iojZS_unzip_nfo_from_zip		true		//unzip *.nfo from *.zip files
#define iojZS_symlink_mp3_sort			false		//sort mp3 rls
#define iojZS_use_ntfs_junction_point		false		//use NFTS to symlink sorted mp3s
#define iojZS_symlink_mp3_genre			false		//sort by genre		iojZS_symlink_mp3_sort must be enabled
#define iojZS_symlink_mp3_year			false		//sort by year		iojZS_symlink_mp3_sort must be enabled
#define iojZS_symlink_mp3_group			false		//sort by group		iojZS_symlink_mp3_sort must be enabled
#define iojZS_symlink_mp3_artist		false		//sort by artist	iojZS_symlink_mp3_sort must be enabled
#define iojZS_benchmark				true		//calculate script execution time
#define iojZS_msg_on_the_fly			false		//write .ioFTPD.message after each file
#define iojZS_msg_on_complete			true		//write .ioFTPD.message when complete
#define iojZS_output_del_reason			true		//when bad file put reasont to client
#define iojZS_delete_no_ext			true		//files with no exstension will be deleted (README,20000,...)
#define iojZS_delete_speedtest			true		//delete file when upped to speedtest dir
#define iojZS_anounce_speedtest			true		//iojZS_irc_speedtest
#define iojZS_anounce_incomplete		true		//anounce if release was complete and file was deleted
#define iojZS_anounce_0byte_file		true		//iojZS_irc_0_byte
#define iojZS_anounce_bad_file			false		//iojZS_irc_bad_file
#define iojZS_anounce_nfo			false		//iojZS_irc_nfo
#define iojZS_anounce_sfv			true		//iojZS_irc_sfv
#define iojZS_anounce_update			true		//iojZS_irc_update
#define iojZS_anounce_mp3_update		true		//iojZS_irc_mp3_update
#define iojZS_anounce_mp3_bad_genre		true		//iojZS_irc_mp3_bad_genre
#define iojZS_get_racers			false		// [%o ] in iojZS_irc_race -->> iojZS_irc_users_race like Jeza is racing [kekec(iND) rozle(TRiAL) ]
#define iojZS_anounce_race			true		//iojZS_irc_race
#define iojZS_anounce_newleader			false		//iojZS_irc_newleader
#define iojZS_anounce_halfway			false		//iojZS_irc_halfway
#define iojZS_anounce_complete			true		//iojZS_irc_complete,iojZS_irc_no_race_complete
#define iojZS_anounce_user_head			false		//iojZS_irc_user_head
#define iojZS_anounce_user_stats		true		//iojZS_irc_user_stats
#define iojZS_anounce_group_head		false		//iojZS_irc_group_head
#define iojZS_anounce_group_stats		true		//iojZS_irc_group_stats
#define iojZS_anounce_rescan			true		//iojZS_irc_rescan when rescan dir
#define iojZS_anounce_zip_norace_complete	true		//iojZS_irc_no_race_complete
#define iojZS_anounce_rar_norace_complete	false		//iojZS_irc_no_race_complete
#define iojZS_anounce_mp3_norace_complete	true		//iojZS_irc_no_race_complete
/***************************/
/*  OUTPUT iRC             */
/***************************/

#define iojZS_irc_speedtest			"%B%u%B made a speedtest at %U%s%UkBps"
#define iojZS_irc_0_byte			"%C04%Binfo%B%C %B%R%B %U0 byte%U File by %B%u%B"
#define iojZS_irc_bad_file			"%C04%Binfo%B%C %B%R%B %UBAD%U File by %B%u%B"
#define iojZS_irc_sfv				"%C03%Bsfv%B%C %B%R%B [%B%t%BF]"
#define iojZS_irc_nfo				"\"%h\" \"%f\" \"%u\" \"%g\""
#define iojZS_irc_update			"%C03%Binfo%B%C %B%R%B [%B%z%B in %B%t%BF]"
#define iojZS_irc_mp3_update			"%C03%Binfo%B%C %B%R%B [%B%z%B in %B%t%BF @ %B%U%X%U%B from %B%Y%B]"
#define iojZS_irc_mp3_bad_genre			"%C04%Binfo%B%C %B%R%B [%B%U%X%U%B Not Allowed Genre]"
#define iojZS_irc_users_race			" %B%u(%r)%B"
#define iojZS_irc_race				"%C03%Brace%B%C %B%R%B by %B%u%B @ %B%s%B kBps"
#define iojZS_irc_newleader			"%C03%Blead%B%C %B%R%B by %B%w%B [%m/%P%%/%fF/%skBps]"
#define iojZS_irc_halfway			"%C03%Bhalfway%B%C %B%R%B Leader is %B%u%B [%m/%P%%/%fF/%skBps] Best Group is %B%g%B [%b/%Q%%/%cF/%qkBps]"
#define iojZS_irc_complete			"%C12%Bcomplete%B%C %B%R%B [%B%e%B in %B%t%BF at %B%J%BkBps in %M]"
#define iojZS_irc_no_race_complete		"%C12%Bcomplete%B%C %B%R%B [%B%m%B in %B%f%BF] by %B%u%B [MNUP Nr. %B%F%B] at %B%s%BkBps in %M"
#define iojZS_irc_incomplete			"%C04%Binfo%B%C %B%R%B is %BiNCOMPLETE%B because %B%u%B deleted %B%f%B"
#define iojZS_irc_user_head			"UserTop:"
#define iojZS_irc_user_stats			"%Bu%p%B. %B%-14u%B [%9m %3P%% %3fF %5skBps] - A/M/W = %B%D%B/%B%F%B/%B%H%B"
#define iojZS_irc_group_head			"GroupTop:"
#define iojZS_irc_group_stats			"%Bg%p%B. %B%-14g%B [%9b %3Q%% %3cF %5qkBps]"
#define iojZS_irc_complete_rescan		"%C12%Brescan%B%C %B%R%B [%B%e%B in %B%t%BF]"
#define iojZS_irc_incomplete_rescan		"%C04%Brescan%B%C %B%R%B [%B%m%BF of %B%t%BF %BMiSSiNG%B]"
/*
#define iojZS_irc_speedtest			"%B%u%B made a speedtest at %U%s%UkBps"
#define iojZS_irc_0_byte			"%C04%BINFO%B%C %B%R%B %U0 byte%U File by %B%u%B"
#define iojZS_irc_bad_file			"%C04%BINFO%B%C %B%R%B %UBAD%U File by %B%u%B"
#define iojZS_irc_sfv				"%C03%BSFV%B%C %B%R%B [%B%t%BF]"
#define iojZS_irc_nfo				"\"%h\" \"%f\" \"%u\" \"%g\""
#define iojZS_irc_update			"%C03%BINFO%B%C %B%R%B [%B%z%B in %B%t%BF]"
#define iojZS_irc_mp3_update			"%C03%BINFO%B%C %B%R%B [%B%z%B in %B%t%BF @ %B%U%X%U%B from %B%Y%B]"
#define iojZS_irc_mp3_bad_genre			"%C04%BINFO%B%C %B%R%B [%B%U%X%U%B Not Allowed Genre]"
#define iojZS_irc_users_race			" %B%u(%r)%B"
#define iojZS_irc_race				"%C03%BRACE%B%C %B%R%B by %B%u%B @ %B%s%B kBps"
#define iojZS_irc_newleader			"%C03%BLEAD%B%C %B%R%B by %B%w%B [%m/%P%%/%fF/%skBps]"
#define iojZS_irc_halfway			"%C03%BHALFWAY%B%C %B%R%B Leader is %B%u%B [%m/%P%%/%fF/%skBps] Best Group is %B%g%B [%b/%Q%%/%cF/%qkBps]"
#define iojZS_irc_complete			"%C12%BCOMPLETE%B%C %B%R%B [%B%e%B in %B%t%BF at %B%J%BkBps in %M]"
#define iojZS_irc_no_race_complete		"%C12%BCOMPLETE%B%C %B%R%B [%B%m%B in %B%f%BF] by %B%u%B [MNUP Nr. %B%F%B] at %B%s%BkBps in %M"
#define iojZS_irc_incomplete			"%C04%BINFO%B%C %B%R%B is %BiNCOMPLETE%B because %B%u%B deleted %B%f%B"
#define iojZS_irc_user_head			"UserTop:"
#define iojZS_irc_user_stats			"%Bu%p%B. %B%-14u%B [%9m %3P%% %3fF %5skBps] - A/M/W = %B%D%B/%B%F%B/%B%H%B"
#define iojZS_irc_group_head			"GroupTop:"
#define iojZS_irc_group_stats			"%Bg%p%B. %B%-14g%B [%9b %3Q%% %3cF %5qkBps]"
#define iojZS_irc_complete_rescan		"%C12%BRESCAN%B%C %B%R%B [%B%e%B in %B%t%BF]"
#define iojZS_irc_incomplete_rescan		"%C04%BRESCAN%B%C %B%R%B [%B%m%BF of %B%t%BF %BMiSSiNG%B]"
*/
/*
SPEEDTEST
0BYTE
BAD
SFV
NFO
UPDATE
WARN
RACE
HALFWAY
NEWLEADER
COMPLETE
STATS
RESCAN
INCOMPLETE
jNEWDIR
jDELDIR
*/