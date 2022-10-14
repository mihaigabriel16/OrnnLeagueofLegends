Public Class Globals
    Public Shared RIOT_API_KEY As String


    Public Shared GameTime = &H3134810 '&H3136040 '&H313AFF0 '&H3111E68 

    Public Shared ObjectManager = &H189E318 '&H189FF7C '&H18A503C '&H187BEC0 
    Public Shared LocalPlayer = &H313AD80 '&H189FF7C '&H3141554 '&H3118DDC 
    Public Shared UnderMouseObject = &H24ED8FC ' Not USED

    Public Shared OHeroList = &H189E2F4 '&H18A0014 '&H18A50D0 '&H187BF54 
    Public Shared OMinionList = &H24EBAE4 '&H24ED788 '&H24F2850 '&H24C9788 
    Public Shared OTurretList = &H3132FDC '&H3134C94 '&H3139D5C '&H3110C94
    Public Shared MissileMap = &H313ADF8 '&H313D2B4 '&H3142288 '&H3117E54 '&H34F848C

    Public Shared ZoomClass = &H31338B8 '&H3135610 '&H313A6D4 '&H31115F8
    Public Shared MaxZoom = &H20 '&H20

    Public Shared Chat = &H313AE7C '&H313D350 '&H31422E4 '&H3118E90 '&H3117EB0 '&H31114A8 '&H310F5E8 '&H31073B8 '&H2FAA734
    Public Shared ChatIsOpen = &H6CC '&H760 '&H718 '&H75C '&H0684

    Public Shared ViewProjMatrices = &H3168C40 '&H316A730 '&H316F328 '&H3148A20 
    Public Shared Renderer = &H316E6AC '&H31701FC '&H3174DF4 '&H314B90C 
    Public Shared RendererWidth = &H8 'ok
    Public Shared RendererHeight = &HC 'ok

    Public Shared MinimapObject = &H3131B80 '&H313383C '&H3138904 '&H310F83C '&H3110E64 '&H31081E8 '&H3100338 '&H2FBC2D0
    Public Shared MinimapObjectHud = &H128 '&H12C '&H124 '&H120 '&H88
    Public Shared MinimapHudPos = &H3C '&H44 '&H60
    Public Shared MinimapHudSize = &H44 '&H48 '&H4C '&H68

    'For objects
    Public Shared ObjectMapCount = &H2C 'ok
    Public Shared ObjectMapRoot = &H28 'ok
    Public Shared ObjectMapNodeNetId = &H10 'ok
    Public Shared ObjectMapNodeObject = &H14 'ok

    Public Shared ObjIndex = &H8 '&H20
    Public Shared ObjTeam = &H34 '&H4C
    Public Shared ObjMissileName = &H54 '&H6C
    Public Shared ObjNetworkID = &HB4 '&HCC
    Public Shared ObjPos = &H1DC '&H1d8
    Public Shared ObjVisibility = &H274 '&H270
    Public Shared ObjSpawnCount = &H288 '&H218
    Public Shared ObjSrcIndex = &H294 '&H290
    Public Shared ObjMana = &H29C '&H298
    Public Shared ObjMaxMana = &H2AC '&H2A8
    Public Shared ObjRecallState = &HD90 '&HD8C
    Public Shared ObjHealth = &HE74 '&HD98
    Public Shared ObjMaxHealth = &HE84 '&HDA8
    Public Shared ObjAbilityHaste = &H16A0 '&H119C '&H1690 
    Public Shared ObjLethality = ObjMagicPen + &H1C '&H11A8 '&H11DC
    Public Shared ObjArmor = &H137C '&H1374 '&H12CC
    Public Shared ObjBonusArmor = &H1380 '&H1378 '&H12C8
    Public Shared ObjMagicRes = &H1384 '&H137C '&H12D4
    Public Shared ObjBonusMagicRes = &H1388 '&H1380 '&H12D4
    Public Shared ObjBaseAtk = &H1354  '&H134C '&H12A4
    Public Shared ObjBonusAtk = &H12CC '&H12C4 '&H121C
    Public Shared ObjMoveSpeed = &H1394 '&H138C '&H12AC '&H12E4
    Public Shared ObjTransformation = &H3070 '&H16A0'&H3040 '&H3040
    Public Shared ObjName = &H2D7C '&H2D3C '&H2BD4 
    Public Shared ObjLvl = &H353C '&H351C '&H33B4 
    Public Shared ObjExpiry = &H298 '&H298
    Public Shared ObjCrit = &H1850 '&H1840 '&H1870 '&H12C8 '&H12C8
    Public Shared ObjCritMulti = &H12B8 '&H1840 '&H12B8 '&H12B4
    Public Shared ObjAbilityPower = &H1750 '&H1740 '&H122C
    Public Shared ObjAtkSpeedMulti = &H1350 '&H1348 '&H12A0
    Public Shared ObjAtkRange = &H139C '&H1394 '&H12EC
    Public Shared ObjTargetable = &HD04 '&HD00
    Public Shared ObjInvulnerable = &H3D4 '&H3D0
    Public Shared ObjIsMoving = &H32E7 '&H3638
    Public Shared ObjDirection = &H1AD0 '&H1F4 '&H1AD0 '&H1B88
    Public Shared ObjItemList = &H35A8 '&H3588 '&H3568 '&H33E8 '&H3400 '&H33E8 '&H3430
    Public Shared ObjExpierience = &H337C '&H33CC
    Public Shared ObjMagicPen = &H1270 '&H126C '&H118C '&H11C0
    Public Shared ObjArmorPen = &H1274 '&H126C '&H118C '&H11C0
    Public Shared ObjMagicPenMulti = ObjMagicPen + &H8 '&H11C8
    Public Shared ObjAdditionalApMulti = &H1248 '&H122C
    Public Shared ObjManaRegen = &H11E0 '&H1134
    Public Shared ObjHealthRegen = &H1390 '&H1388 '&H12D8

    'For Spells
    Public Shared ObjSpellBook = &H2970 '&H2950 '&H27E8
    Public Shared SpellBookActiveSpellCast = &H20 '&H20
    Public Shared SpellBookSpellSlots = &H478 '&H478

    Public Shared SpellSlotLevel = &H1C '&H20
    Public Shared SpellSlotTime = &H24 '&H28
    Public Shared SpellSlotCharges = &H54 '&H58
    Public Shared SpellSlotTimeCharge = &H74 '&H78
    Public Shared SpellSlotDamage = &H94 '&H94
    Public Shared SpellSlotSpellInfo = &H120 '&H13C
    Public Shared SpellInfoSpellData = &H40 '&H44
    Public Shared SpellDataSpellName = &H6C '&H6C
    Public Shared SpellDataMissileName = &H6C '&H78 '&H6C
    Public Shared SpellSlotSmiteTimer = &H60 '&H64
    Public Shared SpellSlotSmiteCharges = &H54 '&H58

    Public Shared SpellCastSpellInfo = &H8 'ok
    Public Shared SpellCastStartTime = &H41 '&H544 'ok
    Public Shared SpellCastStartTimeAlt = &H534 'ok
    Public Shared SpellCastCastTime = &H4C0 'ok
    Public Shared SpellCastStart = &H80 + &H4 'ok
    Public Shared SpellCastEnd = &H8C + &H4 'ok
    Public Shared SpellCastSrcIdx = &H68 'ok
    Public Shared SpellCastDestIdx = &HC0 'ok

    'For Buff
    Public Shared ObjBuffManager = &H2330 '&H21A8
    Public Shared BuffManagerEntriesArray = &H10
    Public Shared BuffEntryBuff = &H8 'ok
    Public Shared BuffType = &H4 'ok
    Public Shared BuffEntryBuffStartTime = &HC 'ok
    Public Shared BuffEntryBuffEndTime = &H10 'ok
    Public Shared BuffEntryBuffCount = &H74 'ok
    Public Shared BuffEntryBuffCountAlt = &H24 'ok
    '  BuffEntryBuffCountAlt2 = &H20
    Public Shared BuffName = &H4 '&H8
    Public Shared BuffEntryBuffNodeStart = &H20 'ok
    Public Shared BuffEntryBuffNodeCurrent = &H24 'ok

    'For Itens
    Public Shared ItemListItem = &HC 'ok
    Public Shared ItemInfo = &H20 'ok
    Public Shared ItemInfoId = &H68 'ok

    'For Missile
    Public Shared MissileMapCount = &H2 '&H8
    Public Shared MissileMapRoot = &H4
    Public Shared MissileMapKey = &H10
    Public Shared MissileMapVal = &H14

    Public Shared MissileSpellInfo = &H260 '&H230
    Public Shared MissileSrcIdx = &H2C4 '&H2DC '&H290
    Public Shared MissileDestIdx = &H318 '&H318 '&H330 '&H330 '&H2E8
    Public Shared MissileDestCheck = &H31C
    Public Shared MissileStartPos = &H2DC '&H2A8
    Public Shared MissileEndPos = &H2E8 '&H2B4
    Public Shared ObjMissileSpellCast = &H250 '&H250

    'For AIManager
    Public Shared AiManager = &H2E54 '&H2E14 '&H2CAC '&H2C7C
    Public Shared AiManagerStartPath = &H1CC
    Public Shared AiManagerEndPath = &H1D8
    Public Shared AiManagerTargetPosition = &H10
    Public Shared AiManagerIsMoving = &H1C0
    Public Shared AiManagerIsDashing = &H214
    Public Shared AiManagerCurrentSegment = &H1C4
    Public Shared AiManagerDashSpeed = &H1F8

    Public Shared ServerPos = &H2EC
    Public Shared Velocity = &H2F8
End Class
