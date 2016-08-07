
#region Comment

/*
 * Project:     FineUI
 * 
 * FileName:    IconType.cs
 * CreatedOn:   2009-09-18
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace FineUI
{
    /// <summary>
    /// 预定义图标
    /// </summary>
    public enum Icon
    {
        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// Accept
        /// </summary>
        Accept,

        /// <summary>
        /// Add
        /// </summary>
        Add,

        /// <summary>
        /// Anchor
        /// </summary>
        Anchor,

        /// <summary>
        /// Application
        /// </summary>
        Application,

        /// <summary>
        /// ApplicationAdd
        /// </summary>
        ApplicationAdd,

        /// <summary>
        /// ApplicationCascade
        /// </summary>
        ApplicationCascade,

        /// <summary>
        /// ApplicationDelete
        /// </summary>
        ApplicationDelete,

        /// <summary>
        /// ApplicationDouble
        /// </summary>
        ApplicationDouble,

        /// <summary>
        /// ApplicationEdit
        /// </summary>
        ApplicationEdit,

        /// <summary>
        /// ApplicationError
        /// </summary>
        ApplicationError,

        /// <summary>
        /// ApplicationForm
        /// </summary>
        ApplicationForm,

        /// <summary>
        /// ApplicationFormAdd
        /// </summary>
        ApplicationFormAdd,

        /// <summary>
        /// ApplicationFormDelete
        /// </summary>
        ApplicationFormDelete,

        /// <summary>
        /// ApplicationFormEdit
        /// </summary>
        ApplicationFormEdit,

        /// <summary>
        /// ApplicationFormMagnify
        /// </summary>
        ApplicationFormMagnify,

        /// <summary>
        /// ApplicationGet
        /// </summary>
        ApplicationGet,

        /// <summary>
        /// ApplicationGo
        /// </summary>
        ApplicationGo,

        /// <summary>
        /// ApplicationHome
        /// </summary>
        ApplicationHome,

        /// <summary>
        /// ApplicationKey
        /// </summary>
        ApplicationKey,

        /// <summary>
        /// ApplicationLightning
        /// </summary>
        ApplicationLightning,

        /// <summary>
        /// ApplicationLink
        /// </summary>
        ApplicationLink,

        /// <summary>
        /// ApplicationOsx
        /// </summary>
        ApplicationOsx,

        /// <summary>
        /// ApplicationOsxAdd
        /// </summary>
        ApplicationOsxAdd,

        /// <summary>
        /// ApplicationOsxCascade
        /// </summary>
        ApplicationOsxCascade,

        /// <summary>
        /// ApplicationOsxDelete
        /// </summary>
        ApplicationOsxDelete,

        /// <summary>
        /// ApplicationOsxDouble
        /// </summary>
        ApplicationOsxDouble,

        /// <summary>
        /// ApplicationOsxError
        /// </summary>
        ApplicationOsxError,

        /// <summary>
        /// ApplicationOsxGet
        /// </summary>
        ApplicationOsxGet,

        /// <summary>
        /// ApplicationOsxGo
        /// </summary>
        ApplicationOsxGo,

        /// <summary>
        /// ApplicationOsxHome
        /// </summary>
        ApplicationOsxHome,

        /// <summary>
        /// ApplicationOsxKey
        /// </summary>
        ApplicationOsxKey,

        /// <summary>
        /// ApplicationOsxLightning
        /// </summary>
        ApplicationOsxLightning,

        /// <summary>
        /// ApplicationOsxLink
        /// </summary>
        ApplicationOsxLink,

        /// <summary>
        /// ApplicationOsxSplit
        /// </summary>
        ApplicationOsxSplit,

        /// <summary>
        /// ApplicationOsxStart
        /// </summary>
        ApplicationOsxStart,

        /// <summary>
        /// ApplicationOsxStop
        /// </summary>
        ApplicationOsxStop,

        /// <summary>
        /// ApplicationOsxTerminal
        /// </summary>
        ApplicationOsxTerminal,

        /// <summary>
        /// ApplicationPut
        /// </summary>
        ApplicationPut,

        /// <summary>
        /// ApplicationSideBoxes
        /// </summary>
        ApplicationSideBoxes,

        /// <summary>
        /// ApplicationSideContract
        /// </summary>
        ApplicationSideContract,

        /// <summary>
        /// ApplicationSideExpand
        /// </summary>
        ApplicationSideExpand,

        /// <summary>
        /// ApplicationSideList
        /// </summary>
        ApplicationSideList,

        /// <summary>
        /// ApplicationSideTree
        /// </summary>
        ApplicationSideTree,

        /// <summary>
        /// ApplicationSplit
        /// </summary>
        ApplicationSplit,

        /// <summary>
        /// ApplicationStart
        /// </summary>
        ApplicationStart,

        /// <summary>
        /// ApplicationStop
        /// </summary>
        ApplicationStop,

        /// <summary>
        /// ApplicationTileHorizontal
        /// </summary>
        ApplicationTileHorizontal,

        /// <summary>
        /// ApplicationTileVertical
        /// </summary>
        ApplicationTileVertical,

        /// <summary>
        /// ApplicationViewColumns
        /// </summary>
        ApplicationViewColumns,

        /// <summary>
        /// ApplicationViewDetail
        /// </summary>
        ApplicationViewDetail,

        /// <summary>
        /// ApplicationViewGallery
        /// </summary>
        ApplicationViewGallery,

        /// <summary>
        /// ApplicationViewIcons
        /// </summary>
        ApplicationViewIcons,

        /// <summary>
        /// ApplicationViewList
        /// </summary>
        ApplicationViewList,

        /// <summary>
        /// ApplicationViewTile
        /// </summary>
        ApplicationViewTile,

        /// <summary>
        /// ApplicationXp
        /// </summary>
        ApplicationXp,

        /// <summary>
        /// ApplicationXpTerminal
        /// </summary>
        ApplicationXpTerminal,

        /// <summary>
        /// ArrowBranch
        /// </summary>
        ArrowBranch,

        /// <summary>
        /// ArrowDivide
        /// </summary>
        ArrowDivide,

        /// <summary>
        /// ArrowDown
        /// </summary>
        ArrowDown,

        /// <summary>
        /// ArrowEw
        /// </summary>
        ArrowEw,

        /// <summary>
        /// ArrowIn
        /// </summary>
        ArrowIn,

        /// <summary>
        /// ArrowInout
        /// </summary>
        ArrowInout,

        /// <summary>
        /// ArrowInLonger
        /// </summary>
        ArrowInLonger,

        /// <summary>
        /// ArrowJoin
        /// </summary>
        ArrowJoin,

        /// <summary>
        /// ArrowLeft
        /// </summary>
        ArrowLeft,

        /// <summary>
        /// ArrowMerge
        /// </summary>
        ArrowMerge,

        /// <summary>
        /// ArrowNe
        /// </summary>
        ArrowNe,

        /// <summary>
        /// ArrowNs
        /// </summary>
        ArrowNs,

        /// <summary>
        /// ArrowNsew
        /// </summary>
        ArrowNsew,

        /// <summary>
        /// ArrowNw
        /// </summary>
        ArrowNw,

        /// <summary>
        /// ArrowNwNeSwSe
        /// </summary>
        ArrowNwNeSwSe,

        /// <summary>
        /// ArrowNwSe
        /// </summary>
        ArrowNwSe,

        /// <summary>
        /// ArrowOut
        /// </summary>
        ArrowOut,

        /// <summary>
        /// ArrowOutLonger
        /// </summary>
        ArrowOutLonger,

        /// <summary>
        /// ArrowRedo
        /// </summary>
        ArrowRedo,

        /// <summary>
        /// ArrowRefresh
        /// </summary>
        ArrowRefresh,

        /// <summary>
        /// ArrowRefreshSmall
        /// </summary>
        ArrowRefreshSmall,

        /// <summary>
        /// ArrowRight
        /// </summary>
        ArrowRight,

        /// <summary>
        /// ArrowRotateAnticlockwise
        /// </summary>
        ArrowRotateAnticlockwise,

        /// <summary>
        /// ArrowRotateClockwise
        /// </summary>
        ArrowRotateClockwise,

        /// <summary>
        /// ArrowSe
        /// </summary>
        ArrowSe,

        /// <summary>
        /// ArrowSw
        /// </summary>
        ArrowSw,

        /// <summary>
        /// ArrowSwitch
        /// </summary>
        ArrowSwitch,

        /// <summary>
        /// ArrowSwitchBluegreen
        /// </summary>
        ArrowSwitchBluegreen,

        /// <summary>
        /// ArrowSwNe
        /// </summary>
        ArrowSwNe,

        /// <summary>
        /// ArrowTurnLeft
        /// </summary>
        ArrowTurnLeft,

        /// <summary>
        /// ArrowTurnRight
        /// </summary>
        ArrowTurnRight,

        /// <summary>
        /// ArrowUndo
        /// </summary>
        ArrowUndo,

        /// <summary>
        /// ArrowUp
        /// </summary>
        ArrowUp,

        /// <summary>
        /// AsteriskOrange
        /// </summary>
        AsteriskOrange,

        /// <summary>
        /// AsteriskRed
        /// </summary>
        AsteriskRed,

        /// <summary>
        /// AsteriskYellow
        /// </summary>
        AsteriskYellow,

        /// <summary>
        /// Attach
        /// </summary>
        Attach,

        /// <summary>
        /// AwardStarAdd
        /// </summary>
        AwardStarAdd,

        /// <summary>
        /// AwardStarBronze1
        /// </summary>
        AwardStarBronze1,

        /// <summary>
        /// AwardStarBronze2
        /// </summary>
        AwardStarBronze2,

        /// <summary>
        /// AwardStarBronze3
        /// </summary>
        AwardStarBronze3,

        /// <summary>
        /// AwardStarDelete
        /// </summary>
        AwardStarDelete,

        /// <summary>
        /// AwardStarGold1
        /// </summary>
        AwardStarGold1,

        /// <summary>
        /// AwardStarGold2
        /// </summary>
        AwardStarGold2,

        /// <summary>
        /// AwardStarGold3
        /// </summary>
        AwardStarGold3,

        /// <summary>
        /// AwardStarSilver1
        /// </summary>
        AwardStarSilver1,

        /// <summary>
        /// AwardStarSilver2
        /// </summary>
        AwardStarSilver2,

        /// <summary>
        /// AwardStarSilver3
        /// </summary>
        AwardStarSilver3,

        /// <summary>
        /// Basket
        /// </summary>
        Basket,

        /// <summary>
        /// BasketAdd
        /// </summary>
        BasketAdd,

        /// <summary>
        /// BasketDelete
        /// </summary>
        BasketDelete,

        /// <summary>
        /// BasketEdit
        /// </summary>
        BasketEdit,

        /// <summary>
        /// BasketError
        /// </summary>
        BasketError,

        /// <summary>
        /// BasketGo
        /// </summary>
        BasketGo,

        /// <summary>
        /// BasketPut
        /// </summary>
        BasketPut,

        /// <summary>
        /// BasketRemove
        /// </summary>
        BasketRemove,

        /// <summary>
        /// Bell
        /// </summary>
        Bell,

        /// <summary>
        /// BellAdd
        /// </summary>
        BellAdd,

        /// <summary>
        /// BellDelete
        /// </summary>
        BellDelete,

        /// <summary>
        /// BellError
        /// </summary>
        BellError,

        /// <summary>
        /// BellGo
        /// </summary>
        BellGo,

        /// <summary>
        /// BellLink
        /// </summary>
        BellLink,

        /// <summary>
        /// BellSilver
        /// </summary>
        BellSilver,

        /// <summary>
        /// BellSilverStart
        /// </summary>
        BellSilverStart,

        /// <summary>
        /// BellSilverStop
        /// </summary>
        BellSilverStop,

        /// <summary>
        /// BellStart
        /// </summary>
        BellStart,

        /// <summary>
        /// BellStop
        /// </summary>
        BellStop,

        /// <summary>
        /// Bin
        /// </summary>
        Bin,

        /// <summary>
        /// BinClosed
        /// </summary>
        BinClosed,

        /// <summary>
        /// BinEmpty
        /// </summary>
        BinEmpty,

        /// <summary>
        /// Blank
        /// </summary>
        Blank,

        /// <summary>
        /// Bomb
        /// </summary>
        Bomb,

        /// <summary>
        /// Book
        /// </summary>
        Book,

        /// <summary>
        /// Bookmark
        /// </summary>
        Bookmark,

        /// <summary>
        /// BookmarkAdd
        /// </summary>
        BookmarkAdd,

        /// <summary>
        /// BookmarkDelete
        /// </summary>
        BookmarkDelete,

        /// <summary>
        /// BookmarkEdit
        /// </summary>
        BookmarkEdit,

        /// <summary>
        /// BookmarkError
        /// </summary>
        BookmarkError,

        /// <summary>
        /// BookmarkGo
        /// </summary>
        BookmarkGo,

        /// <summary>
        /// BookAdd
        /// </summary>
        BookAdd,

        /// <summary>
        /// BookAddresses
        /// </summary>
        BookAddresses,

        /// <summary>
        /// BookAddressesAdd
        /// </summary>
        BookAddressesAdd,

        /// <summary>
        /// BookAddressesDelete
        /// </summary>
        BookAddressesDelete,

        /// <summary>
        /// BookAddressesEdit
        /// </summary>
        BookAddressesEdit,

        /// <summary>
        /// BookAddressesError
        /// </summary>
        BookAddressesError,

        /// <summary>
        /// BookAddressesKey
        /// </summary>
        BookAddressesKey,

        /// <summary>
        /// BookDelete
        /// </summary>
        BookDelete,

        /// <summary>
        /// BookEdit
        /// </summary>
        BookEdit,

        /// <summary>
        /// BookError
        /// </summary>
        BookError,

        /// <summary>
        /// BookGo
        /// </summary>
        BookGo,

        /// <summary>
        /// BookKey
        /// </summary>
        BookKey,

        /// <summary>
        /// BookLink
        /// </summary>
        BookLink,

        /// <summary>
        /// BookMagnify
        /// </summary>
        BookMagnify,

        /// <summary>
        /// BookNext
        /// </summary>
        BookNext,

        /// <summary>
        /// BookOpen
        /// </summary>
        BookOpen,

        /// <summary>
        /// BookOpenMark
        /// </summary>
        BookOpenMark,

        /// <summary>
        /// BookPrevious
        /// </summary>
        BookPrevious,

        /// <summary>
        /// BookRed
        /// </summary>
        BookRed,

        /// <summary>
        /// BookTabs
        /// </summary>
        BookTabs,

        /// <summary>
        /// BorderAll
        /// </summary>
        BorderAll,

        /// <summary>
        /// BorderBottom
        /// </summary>
        BorderBottom,

        /// <summary>
        /// BorderDraw
        /// </summary>
        BorderDraw,

        /// <summary>
        /// BorderInner
        /// </summary>
        BorderInner,

        /// <summary>
        /// BorderInnerHorizontal
        /// </summary>
        BorderInnerHorizontal,

        /// <summary>
        /// BorderInnerVertical
        /// </summary>
        BorderInnerVertical,

        /// <summary>
        /// BorderLeft
        /// </summary>
        BorderLeft,

        /// <summary>
        /// BorderNone
        /// </summary>
        BorderNone,

        /// <summary>
        /// BorderOuter
        /// </summary>
        BorderOuter,

        /// <summary>
        /// BorderRight
        /// </summary>
        BorderRight,

        /// <summary>
        /// BorderTop
        /// </summary>
        BorderTop,

        /// <summary>
        /// Box
        /// </summary>
        Box,

        /// <summary>
        /// BoxError
        /// </summary>
        BoxError,

        /// <summary>
        /// BoxPicture
        /// </summary>
        BoxPicture,

        /// <summary>
        /// BoxWorld
        /// </summary>
        BoxWorld,

        /// <summary>
        /// Brick
        /// </summary>
        Brick,

        /// <summary>
        /// Bricks
        /// </summary>
        Bricks,

        /// <summary>
        /// BrickAdd
        /// </summary>
        BrickAdd,

        /// <summary>
        /// BrickDelete
        /// </summary>
        BrickDelete,

        /// <summary>
        /// BrickEdit
        /// </summary>
        BrickEdit,

        /// <summary>
        /// BrickError
        /// </summary>
        BrickError,

        /// <summary>
        /// BrickGo
        /// </summary>
        BrickGo,

        /// <summary>
        /// BrickLink
        /// </summary>
        BrickLink,

        /// <summary>
        /// BrickMagnify
        /// </summary>
        BrickMagnify,

        /// <summary>
        /// Briefcase
        /// </summary>
        Briefcase,

        /// <summary>
        /// Bug
        /// </summary>
        Bug,

        /// <summary>
        /// BugAdd
        /// </summary>
        BugAdd,

        /// <summary>
        /// BugDelete
        /// </summary>
        BugDelete,

        /// <summary>
        /// BugEdit
        /// </summary>
        BugEdit,

        /// <summary>
        /// BugError
        /// </summary>
        BugError,

        /// <summary>
        /// BugFix
        /// </summary>
        BugFix,

        /// <summary>
        /// BugGo
        /// </summary>
        BugGo,

        /// <summary>
        /// BugLink
        /// </summary>
        BugLink,

        /// <summary>
        /// BugMagnify
        /// </summary>
        BugMagnify,

        /// <summary>
        /// Build
        /// </summary>
        Build,

        /// <summary>
        /// Building
        /// </summary>
        Building,

        /// <summary>
        /// BuildingAdd
        /// </summary>
        BuildingAdd,

        /// <summary>
        /// BuildingDelete
        /// </summary>
        BuildingDelete,

        /// <summary>
        /// BuildingEdit
        /// </summary>
        BuildingEdit,

        /// <summary>
        /// BuildingError
        /// </summary>
        BuildingError,

        /// <summary>
        /// BuildingGo
        /// </summary>
        BuildingGo,

        /// <summary>
        /// BuildingKey
        /// </summary>
        BuildingKey,

        /// <summary>
        /// BuildingLink
        /// </summary>
        BuildingLink,

        /// <summary>
        /// BuildCancel
        /// </summary>
        BuildCancel,

        /// <summary>
        /// BulletAdd
        /// </summary>
        BulletAdd,

        /// <summary>
        /// BulletArrowBottom
        /// </summary>
        BulletArrowBottom,

        /// <summary>
        /// BulletArrowDown
        /// </summary>
        BulletArrowDown,

        /// <summary>
        /// BulletArrowTop
        /// </summary>
        BulletArrowTop,

        /// <summary>
        /// BulletArrowUp
        /// </summary>
        BulletArrowUp,

        /// <summary>
        /// BulletBlack
        /// </summary>
        BulletBlack,

        /// <summary>
        /// BulletBlue
        /// </summary>
        BulletBlue,

        /// <summary>
        /// BulletConnect
        /// </summary>
        BulletConnect,

        /// <summary>
        /// BulletCross
        /// </summary>
        BulletCross,

        /// <summary>
        /// BulletDatabase
        /// </summary>
        BulletDatabase,

        /// <summary>
        /// BulletDatabaseYellow
        /// </summary>
        BulletDatabaseYellow,

        /// <summary>
        /// BulletDelete
        /// </summary>
        BulletDelete,

        /// <summary>
        /// BulletDisk
        /// </summary>
        BulletDisk,

        /// <summary>
        /// BulletEarth
        /// </summary>
        BulletEarth,

        /// <summary>
        /// BulletEdit
        /// </summary>
        BulletEdit,

        /// <summary>
        /// BulletEject
        /// </summary>
        BulletEject,

        /// <summary>
        /// BulletError
        /// </summary>
        BulletError,

        /// <summary>
        /// BulletFeed
        /// </summary>
        BulletFeed,

        /// <summary>
        /// BulletGet
        /// </summary>
        BulletGet,

        /// <summary>
        /// BulletGo
        /// </summary>
        BulletGo,

        /// <summary>
        /// BulletGreen
        /// </summary>
        BulletGreen,

        /// <summary>
        /// BulletHome
        /// </summary>
        BulletHome,

        /// <summary>
        /// BulletKey
        /// </summary>
        BulletKey,

        /// <summary>
        /// BulletLeft
        /// </summary>
        BulletLeft,

        /// <summary>
        /// BulletLightning
        /// </summary>
        BulletLightning,

        /// <summary>
        /// BulletMagnify
        /// </summary>
        BulletMagnify,

        /// <summary>
        /// BulletMinus
        /// </summary>
        BulletMinus,

        /// <summary>
        /// BulletOrange
        /// </summary>
        BulletOrange,

        /// <summary>
        /// BulletPageWhite
        /// </summary>
        BulletPageWhite,

        /// <summary>
        /// BulletPicture
        /// </summary>
        BulletPicture,

        /// <summary>
        /// BulletPink
        /// </summary>
        BulletPink,

        /// <summary>
        /// BulletPlus
        /// </summary>
        BulletPlus,

        /// <summary>
        /// BulletPurple
        /// </summary>
        BulletPurple,

        /// <summary>
        /// BulletRed
        /// </summary>
        BulletRed,

        /// <summary>
        /// BulletRight
        /// </summary>
        BulletRight,

        /// <summary>
        /// BulletShape
        /// </summary>
        BulletShape,

        /// <summary>
        /// BulletSparkle
        /// </summary>
        BulletSparkle,

        /// <summary>
        /// BulletStar
        /// </summary>
        BulletStar,

        /// <summary>
        /// BulletStart
        /// </summary>
        BulletStart,

        /// <summary>
        /// BulletStop
        /// </summary>
        BulletStop,

        /// <summary>
        /// BulletStopAlt
        /// </summary>
        BulletStopAlt,

        /// <summary>
        /// BulletTick
        /// </summary>
        BulletTick,

        /// <summary>
        /// BulletToggleMinus
        /// </summary>
        BulletToggleMinus,

        /// <summary>
        /// BulletTogglePlus
        /// </summary>
        BulletTogglePlus,

        /// <summary>
        /// BulletWhite
        /// </summary>
        BulletWhite,

        /// <summary>
        /// BulletWrench
        /// </summary>
        BulletWrench,

        /// <summary>
        /// BulletWrenchRed
        /// </summary>
        BulletWrenchRed,

        /// <summary>
        /// BulletYellow
        /// </summary>
        BulletYellow,

        /// <summary>
        /// Button
        /// </summary>
        Button,

        /// <summary>
        /// Cake
        /// </summary>
        Cake,

        /// <summary>
        /// CakeOut
        /// </summary>
        CakeOut,

        /// <summary>
        /// CakeSliced
        /// </summary>
        CakeSliced,

        /// <summary>
        /// Calculator
        /// </summary>
        Calculator,

        /// <summary>
        /// CalculatorAdd
        /// </summary>
        CalculatorAdd,

        /// <summary>
        /// CalculatorDelete
        /// </summary>
        CalculatorDelete,

        /// <summary>
        /// CalculatorEdit
        /// </summary>
        CalculatorEdit,

        /// <summary>
        /// CalculatorError
        /// </summary>
        CalculatorError,

        /// <summary>
        /// CalculatorLink
        /// </summary>
        CalculatorLink,

        /// <summary>
        /// Calendar
        /// </summary>
        Calendar,

        /// <summary>
        /// CalendarAdd
        /// </summary>
        CalendarAdd,

        /// <summary>
        /// CalendarDelete
        /// </summary>
        CalendarDelete,

        /// <summary>
        /// CalendarEdit
        /// </summary>
        CalendarEdit,

        /// <summary>
        /// CalendarLink
        /// </summary>
        CalendarLink,

        /// <summary>
        /// CalendarSelectDay
        /// </summary>
        CalendarSelectDay,

        /// <summary>
        /// CalendarSelectNone
        /// </summary>
        CalendarSelectNone,

        /// <summary>
        /// CalendarSelectWeek
        /// </summary>
        CalendarSelectWeek,

        /// <summary>
        /// CalendarStar
        /// </summary>
        CalendarStar,

        /// <summary>
        /// CalendarViewDay
        /// </summary>
        CalendarViewDay,

        /// <summary>
        /// CalendarViewMonth
        /// </summary>
        CalendarViewMonth,

        /// <summary>
        /// CalendarViewWeek
        /// </summary>
        CalendarViewWeek,

        /// <summary>
        /// Camera
        /// </summary>
        Camera,

        /// <summary>
        /// CameraAdd
        /// </summary>
        CameraAdd,

        /// <summary>
        /// CameraConnect
        /// </summary>
        CameraConnect,

        /// <summary>
        /// CameraDelete
        /// </summary>
        CameraDelete,

        /// <summary>
        /// CameraEdit
        /// </summary>
        CameraEdit,

        /// <summary>
        /// CameraError
        /// </summary>
        CameraError,

        /// <summary>
        /// CameraGo
        /// </summary>
        CameraGo,

        /// <summary>
        /// CameraLink
        /// </summary>
        CameraLink,

        /// <summary>
        /// CameraMagnify
        /// </summary>
        CameraMagnify,

        /// <summary>
        /// CameraPicture
        /// </summary>
        CameraPicture,

        /// <summary>
        /// CameraSmall
        /// </summary>
        CameraSmall,

        /// <summary>
        /// CameraStart
        /// </summary>
        CameraStart,

        /// <summary>
        /// CameraStop
        /// </summary>
        CameraStop,

        /// <summary>
        /// Cancel
        /// </summary>
        Cancel,

        /// <summary>
        /// Car
        /// </summary>
        Car,

        /// <summary>
        /// Cart
        /// </summary>
        Cart,

        /// <summary>
        /// CartAdd
        /// </summary>
        CartAdd,

        /// <summary>
        /// CartDelete
        /// </summary>
        CartDelete,

        /// <summary>
        /// CartEdit
        /// </summary>
        CartEdit,

        /// <summary>
        /// CartError
        /// </summary>
        CartError,

        /// <summary>
        /// CartFull
        /// </summary>
        CartFull,

        /// <summary>
        /// CartGo
        /// </summary>
        CartGo,

        /// <summary>
        /// CartMagnify
        /// </summary>
        CartMagnify,

        /// <summary>
        /// CartPut
        /// </summary>
        CartPut,

        /// <summary>
        /// CartRemove
        /// </summary>
        CartRemove,

        /// <summary>
        /// CarAdd
        /// </summary>
        CarAdd,

        /// <summary>
        /// CarDelete
        /// </summary>
        CarDelete,

        /// <summary>
        /// CarError
        /// </summary>
        CarError,

        /// <summary>
        /// CarRed
        /// </summary>
        CarRed,

        /// <summary>
        /// CarStart
        /// </summary>
        CarStart,

        /// <summary>
        /// CarStop
        /// </summary>
        CarStop,

        /// <summary>
        /// Cd
        /// </summary>
        Cd,

        /// <summary>
        /// Cdr
        /// </summary>
        Cdr,

        /// <summary>
        /// CdrAdd
        /// </summary>
        CdrAdd,

        /// <summary>
        /// CdrBurn
        /// </summary>
        CdrBurn,

        /// <summary>
        /// CdrCross
        /// </summary>
        CdrCross,

        /// <summary>
        /// CdrDelete
        /// </summary>
        CdrDelete,

        /// <summary>
        /// CdrEdit
        /// </summary>
        CdrEdit,

        /// <summary>
        /// CdrEject
        /// </summary>
        CdrEject,

        /// <summary>
        /// CdrError
        /// </summary>
        CdrError,

        /// <summary>
        /// CdrGo
        /// </summary>
        CdrGo,

        /// <summary>
        /// CdrMagnify
        /// </summary>
        CdrMagnify,

        /// <summary>
        /// CdrPlay
        /// </summary>
        CdrPlay,

        /// <summary>
        /// CdrStart
        /// </summary>
        CdrStart,

        /// <summary>
        /// CdrStop
        /// </summary>
        CdrStop,

        /// <summary>
        /// CdrStopAlt
        /// </summary>
        CdrStopAlt,

        /// <summary>
        /// CdrTick
        /// </summary>
        CdrTick,

        /// <summary>
        /// CdAdd
        /// </summary>
        CdAdd,

        /// <summary>
        /// CdBurn
        /// </summary>
        CdBurn,

        /// <summary>
        /// CdDelete
        /// </summary>
        CdDelete,

        /// <summary>
        /// CdEdit
        /// </summary>
        CdEdit,

        /// <summary>
        /// CdEject
        /// </summary>
        CdEject,

        /// <summary>
        /// CdGo
        /// </summary>
        CdGo,

        /// <summary>
        /// CdMagnify
        /// </summary>
        CdMagnify,

        /// <summary>
        /// CdPlay
        /// </summary>
        CdPlay,

        /// <summary>
        /// CdStop
        /// </summary>
        CdStop,

        /// <summary>
        /// CdStopAlt
        /// </summary>
        CdStopAlt,

        /// <summary>
        /// CdTick
        /// </summary>
        CdTick,

        /// <summary>
        /// ChartBar
        /// </summary>
        ChartBar,

        /// <summary>
        /// ChartBarAdd
        /// </summary>
        ChartBarAdd,

        /// <summary>
        /// ChartBarDelete
        /// </summary>
        ChartBarDelete,

        /// <summary>
        /// ChartBarEdit
        /// </summary>
        ChartBarEdit,

        /// <summary>
        /// ChartBarError
        /// </summary>
        ChartBarError,

        /// <summary>
        /// ChartBarLink
        /// </summary>
        ChartBarLink,

        /// <summary>
        /// ChartCurve
        /// </summary>
        ChartCurve,

        /// <summary>
        /// ChartCurveAdd
        /// </summary>
        ChartCurveAdd,

        /// <summary>
        /// ChartCurveDelete
        /// </summary>
        ChartCurveDelete,

        /// <summary>
        /// ChartCurveEdit
        /// </summary>
        ChartCurveEdit,

        /// <summary>
        /// ChartCurveError
        /// </summary>
        ChartCurveError,

        /// <summary>
        /// ChartCurveGo
        /// </summary>
        ChartCurveGo,

        /// <summary>
        /// ChartCurveLink
        /// </summary>
        ChartCurveLink,

        /// <summary>
        /// ChartLine
        /// </summary>
        ChartLine,

        /// <summary>
        /// ChartLineAdd
        /// </summary>
        ChartLineAdd,

        /// <summary>
        /// ChartLineDelete
        /// </summary>
        ChartLineDelete,

        /// <summary>
        /// ChartLineEdit
        /// </summary>
        ChartLineEdit,

        /// <summary>
        /// ChartLineError
        /// </summary>
        ChartLineError,

        /// <summary>
        /// ChartLineLink
        /// </summary>
        ChartLineLink,

        /// <summary>
        /// ChartOrganisation
        /// </summary>
        ChartOrganisation,

        /// <summary>
        /// ChartOrganisationAdd
        /// </summary>
        ChartOrganisationAdd,

        /// <summary>
        /// ChartOrganisationDelete
        /// </summary>
        ChartOrganisationDelete,

        /// <summary>
        /// ChartOrgInverted
        /// </summary>
        ChartOrgInverted,

        /// <summary>
        /// ChartPie
        /// </summary>
        ChartPie,

        /// <summary>
        /// ChartPieAdd
        /// </summary>
        ChartPieAdd,

        /// <summary>
        /// ChartPieDelete
        /// </summary>
        ChartPieDelete,

        /// <summary>
        /// ChartPieEdit
        /// </summary>
        ChartPieEdit,

        /// <summary>
        /// ChartPieError
        /// </summary>
        ChartPieError,

        /// <summary>
        /// ChartPieLightning
        /// </summary>
        ChartPieLightning,

        /// <summary>
        /// ChartPieLink
        /// </summary>
        ChartPieLink,

        /// <summary>
        /// CheckError
        /// </summary>
        CheckError,

        /// <summary>
        /// Clipboard
        /// </summary>
        Clipboard,

        /// <summary>
        /// Clock
        /// </summary>
        Clock,

        /// <summary>
        /// ClockAdd
        /// </summary>
        ClockAdd,

        /// <summary>
        /// ClockDelete
        /// </summary>
        ClockDelete,

        /// <summary>
        /// ClockEdit
        /// </summary>
        ClockEdit,

        /// <summary>
        /// ClockError
        /// </summary>
        ClockError,

        /// <summary>
        /// ClockGo
        /// </summary>
        ClockGo,

        /// <summary>
        /// ClockLink
        /// </summary>
        ClockLink,

        /// <summary>
        /// ClockPause
        /// </summary>
        ClockPause,

        /// <summary>
        /// ClockPlay
        /// </summary>
        ClockPlay,

        /// <summary>
        /// ClockRed
        /// </summary>
        ClockRed,

        /// <summary>
        /// ClockStart
        /// </summary>
        ClockStart,

        /// <summary>
        /// ClockStop
        /// </summary>
        ClockStop,

        /// <summary>
        /// ClockStop2
        /// </summary>
        ClockStop2,

        /// <summary>
        /// Cmy
        /// </summary>
        Cmy,

        /// <summary>
        /// Cog
        /// </summary>
        Cog,

        /// <summary>
        /// CogAdd
        /// </summary>
        CogAdd,

        /// <summary>
        /// CogDelete
        /// </summary>
        CogDelete,

        /// <summary>
        /// CogEdit
        /// </summary>
        CogEdit,

        /// <summary>
        /// CogError
        /// </summary>
        CogError,

        /// <summary>
        /// CogGo
        /// </summary>
        CogGo,

        /// <summary>
        /// CogStart
        /// </summary>
        CogStart,

        /// <summary>
        /// CogStop
        /// </summary>
        CogStop,

        /// <summary>
        /// Coins
        /// </summary>
        Coins,

        /// <summary>
        /// CoinsAdd
        /// </summary>
        CoinsAdd,

        /// <summary>
        /// CoinsDelete
        /// </summary>
        CoinsDelete,

        /// <summary>
        /// Color
        /// </summary>
        Color,

        /// <summary>
        /// ColorSwatch
        /// </summary>
        ColorSwatch,

        /// <summary>
        /// ColorWheel
        /// </summary>
        ColorWheel,

        /// <summary>
        /// Comment
        /// </summary>
        Comment,

        /// <summary>
        /// Comments
        /// </summary>
        Comments,

        /// <summary>
        /// CommentsAdd
        /// </summary>
        CommentsAdd,

        /// <summary>
        /// CommentsDelete
        /// </summary>
        CommentsDelete,

        /// <summary>
        /// CommentAdd
        /// </summary>
        CommentAdd,

        /// <summary>
        /// CommentDelete
        /// </summary>
        CommentDelete,

        /// <summary>
        /// CommentDull
        /// </summary>
        CommentDull,

        /// <summary>
        /// CommentEdit
        /// </summary>
        CommentEdit,

        /// <summary>
        /// CommentPlay
        /// </summary>
        CommentPlay,

        /// <summary>
        /// CommentRecord
        /// </summary>
        CommentRecord,

        /// <summary>
        /// Compass
        /// </summary>
        Compass,

        /// <summary>
        /// Compress
        /// </summary>
        Compress,

        /// <summary>
        /// Computer
        /// </summary>
        Computer,

        /// <summary>
        /// ComputerAdd
        /// </summary>
        ComputerAdd,

        /// <summary>
        /// ComputerConnect
        /// </summary>
        ComputerConnect,

        /// <summary>
        /// ComputerDelete
        /// </summary>
        ComputerDelete,

        /// <summary>
        /// ComputerEdit
        /// </summary>
        ComputerEdit,

        /// <summary>
        /// ComputerError
        /// </summary>
        ComputerError,

        /// <summary>
        /// ComputerGo
        /// </summary>
        ComputerGo,

        /// <summary>
        /// ComputerKey
        /// </summary>
        ComputerKey,

        /// <summary>
        /// ComputerLink
        /// </summary>
        ComputerLink,

        /// <summary>
        /// ComputerMagnify
        /// </summary>
        ComputerMagnify,

        /// <summary>
        /// ComputerOff
        /// </summary>
        ComputerOff,

        /// <summary>
        /// ComputerStart
        /// </summary>
        ComputerStart,

        /// <summary>
        /// ComputerStop
        /// </summary>
        ComputerStop,

        /// <summary>
        /// ComputerWrench
        /// </summary>
        ComputerWrench,

        /// <summary>
        /// Connect
        /// </summary>
        Connect,

        /// <summary>
        /// Contrast
        /// </summary>
        Contrast,

        /// <summary>
        /// ContrastDecrease
        /// </summary>
        ContrastDecrease,

        /// <summary>
        /// ContrastHigh
        /// </summary>
        ContrastHigh,

        /// <summary>
        /// ContrastIncrease
        /// </summary>
        ContrastIncrease,

        /// <summary>
        /// ContrastLow
        /// </summary>
        ContrastLow,

        /// <summary>
        /// Controller
        /// </summary>
        Controller,

        /// <summary>
        /// ControllerAdd
        /// </summary>
        ControllerAdd,

        /// <summary>
        /// ControllerDelete
        /// </summary>
        ControllerDelete,

        /// <summary>
        /// ControllerError
        /// </summary>
        ControllerError,

        /// <summary>
        /// ControlAdd
        /// </summary>
        ControlAdd,

        /// <summary>
        /// ControlAddBlue
        /// </summary>
        ControlAddBlue,

        /// <summary>
        /// ControlBlank
        /// </summary>
        ControlBlank,

        /// <summary>
        /// ControlBlankBlue
        /// </summary>
        ControlBlankBlue,

        /// <summary>
        /// ControlEject
        /// </summary>
        ControlEject,

        /// <summary>
        /// ControlEjectBlue
        /// </summary>
        ControlEjectBlue,

        /// <summary>
        /// ControlEnd
        /// </summary>
        ControlEnd,

        /// <summary>
        /// ControlEndBlue
        /// </summary>
        ControlEndBlue,

        /// <summary>
        /// ControlEqualizer
        /// </summary>
        ControlEqualizer,

        /// <summary>
        /// ControlEqualizerBlue
        /// </summary>
        ControlEqualizerBlue,

        /// <summary>
        /// ControlFastforward
        /// </summary>
        ControlFastforward,

        /// <summary>
        /// ControlFastforwardBlue
        /// </summary>
        ControlFastforwardBlue,

        /// <summary>
        /// ControlPause
        /// </summary>
        ControlPause,

        /// <summary>
        /// ControlPauseBlue
        /// </summary>
        ControlPauseBlue,

        /// <summary>
        /// ControlPlay
        /// </summary>
        ControlPlay,

        /// <summary>
        /// ControlPlayBlue
        /// </summary>
        ControlPlayBlue,

        /// <summary>
        /// ControlPower
        /// </summary>
        ControlPower,

        /// <summary>
        /// ControlPowerBlue
        /// </summary>
        ControlPowerBlue,

        /// <summary>
        /// ControlRecord
        /// </summary>
        ControlRecord,

        /// <summary>
        /// ControlRecordBlue
        /// </summary>
        ControlRecordBlue,

        /// <summary>
        /// ControlRemove
        /// </summary>
        ControlRemove,

        /// <summary>
        /// ControlRemoveBlue
        /// </summary>
        ControlRemoveBlue,

        /// <summary>
        /// ControlRepeat
        /// </summary>
        ControlRepeat,

        /// <summary>
        /// ControlRepeatBlue
        /// </summary>
        ControlRepeatBlue,

        /// <summary>
        /// ControlRewind
        /// </summary>
        ControlRewind,

        /// <summary>
        /// ControlRewindBlue
        /// </summary>
        ControlRewindBlue,

        /// <summary>
        /// ControlStart
        /// </summary>
        ControlStart,

        /// <summary>
        /// ControlStartBlue
        /// </summary>
        ControlStartBlue,

        /// <summary>
        /// ControlStop
        /// </summary>
        ControlStop,

        /// <summary>
        /// ControlStopBlue
        /// </summary>
        ControlStopBlue,

        /// <summary>
        /// Creditcards
        /// </summary>
        Creditcards,

        /// <summary>
        /// Cross
        /// </summary>
        Cross,

        /// <summary>
        /// Css
        /// </summary>
        Css,

        /// <summary>
        /// CssAdd
        /// </summary>
        CssAdd,

        /// <summary>
        /// CssDelete
        /// </summary>
        CssDelete,

        /// <summary>
        /// CssError
        /// </summary>
        CssError,

        /// <summary>
        /// CssGo
        /// </summary>
        CssGo,

        /// <summary>
        /// CssValid
        /// </summary>
        CssValid,

        /// <summary>
        /// Cup
        /// </summary>
        Cup,

        /// <summary>
        /// CupAdd
        /// </summary>
        CupAdd,

        /// <summary>
        /// CupBlack
        /// </summary>
        CupBlack,

        /// <summary>
        /// CupDelete
        /// </summary>
        CupDelete,

        /// <summary>
        /// CupEdit
        /// </summary>
        CupEdit,

        /// <summary>
        /// CupError
        /// </summary>
        CupError,

        /// <summary>
        /// CupGo
        /// </summary>
        CupGo,

        /// <summary>
        /// CupGreen
        /// </summary>
        CupGreen,

        /// <summary>
        /// CupKey
        /// </summary>
        CupKey,

        /// <summary>
        /// CupLink
        /// </summary>
        CupLink,

        /// <summary>
        /// CupTea
        /// </summary>
        CupTea,

        /// <summary>
        /// Cursor
        /// </summary>
        Cursor,

        /// <summary>
        /// CursorSmall
        /// </summary>
        CursorSmall,

        /// <summary>
        /// Cut
        /// </summary>
        Cut,

        /// <summary>
        /// CutRed
        /// </summary>
        CutRed,

        /// <summary>
        /// Database
        /// </summary>
        Database,

        /// <summary>
        /// DatabaseAdd
        /// </summary>
        DatabaseAdd,

        /// <summary>
        /// DatabaseConnect
        /// </summary>
        DatabaseConnect,

        /// <summary>
        /// DatabaseCopy
        /// </summary>
        DatabaseCopy,

        /// <summary>
        /// DatabaseDelete
        /// </summary>
        DatabaseDelete,

        /// <summary>
        /// DatabaseEdit
        /// </summary>
        DatabaseEdit,

        /// <summary>
        /// DatabaseError
        /// </summary>
        DatabaseError,

        /// <summary>
        /// DatabaseGear
        /// </summary>
        DatabaseGear,

        /// <summary>
        /// DatabaseGo
        /// </summary>
        DatabaseGo,

        /// <summary>
        /// DatabaseKey
        /// </summary>
        DatabaseKey,

        /// <summary>
        /// DatabaseLightning
        /// </summary>
        DatabaseLightning,

        /// <summary>
        /// DatabaseLink
        /// </summary>
        DatabaseLink,

        /// <summary>
        /// DatabaseRefresh
        /// </summary>
        DatabaseRefresh,

        /// <summary>
        /// DatabaseSave
        /// </summary>
        DatabaseSave,

        /// <summary>
        /// DatabaseStart
        /// </summary>
        DatabaseStart,

        /// <summary>
        /// DatabaseStop
        /// </summary>
        DatabaseStop,

        /// <summary>
        /// DatabaseTable
        /// </summary>
        DatabaseTable,

        /// <summary>
        /// DatabaseWrench
        /// </summary>
        DatabaseWrench,

        /// <summary>
        /// DatabaseYellow
        /// </summary>
        DatabaseYellow,

        /// <summary>
        /// DatabaseYellowStart
        /// </summary>
        DatabaseYellowStart,

        /// <summary>
        /// DatabaseYellowStop
        /// </summary>
        DatabaseYellowStop,

        /// <summary>
        /// Date
        /// </summary>
        Date,

        /// <summary>
        /// DateAdd
        /// </summary>
        DateAdd,

        /// <summary>
        /// DateDelete
        /// </summary>
        DateDelete,

        /// <summary>
        /// DateEdit
        /// </summary>
        DateEdit,

        /// <summary>
        /// DateError
        /// </summary>
        DateError,

        /// <summary>
        /// DateGo
        /// </summary>
        DateGo,

        /// <summary>
        /// DateLink
        /// </summary>
        DateLink,

        /// <summary>
        /// DateMagnify
        /// </summary>
        DateMagnify,

        /// <summary>
        /// DateNext
        /// </summary>
        DateNext,

        /// <summary>
        /// DatePrevious
        /// </summary>
        DatePrevious,

        /// <summary>
        /// Decline
        /// </summary>
        Decline,

        /// <summary>
        /// Delete
        /// </summary>
        Delete,

        /// <summary>
        /// DeviceStylus
        /// </summary>
        DeviceStylus,

        /// <summary>
        /// Disconnect
        /// </summary>
        Disconnect,

        /// <summary>
        /// Disk
        /// </summary>
        Disk,

        /// <summary>
        /// DiskBlack
        /// </summary>
        DiskBlack,

        /// <summary>
        /// DiskBlackError
        /// </summary>
        DiskBlackError,

        /// <summary>
        /// DiskBlackMagnify
        /// </summary>
        DiskBlackMagnify,

        /// <summary>
        /// DiskDownload
        /// </summary>
        DiskDownload,

        /// <summary>
        /// DiskEdit
        /// </summary>
        DiskEdit,

        /// <summary>
        /// DiskError
        /// </summary>
        DiskError,

        /// <summary>
        /// DiskMagnify
        /// </summary>
        DiskMagnify,

        /// <summary>
        /// DiskMultiple
        /// </summary>
        DiskMultiple,

        /// <summary>
        /// DiskUpload
        /// </summary>
        DiskUpload,

        /// <summary>
        /// Door
        /// </summary>
        Door,

        /// <summary>
        /// DoorError
        /// </summary>
        DoorError,

        /// <summary>
        /// DoorIn
        /// </summary>
        DoorIn,

        /// <summary>
        /// DoorOpen
        /// </summary>
        DoorOpen,

        /// <summary>
        /// DoorOut
        /// </summary>
        DoorOut,

        /// <summary>
        /// Drink
        /// </summary>
        Drink,

        /// <summary>
        /// DrinkEmpty
        /// </summary>
        DrinkEmpty,

        /// <summary>
        /// DrinkRed
        /// </summary>
        DrinkRed,

        /// <summary>
        /// Drive
        /// </summary>
        Drive,

        /// <summary>
        /// DriveAdd
        /// </summary>
        DriveAdd,

        /// <summary>
        /// DriveBurn
        /// </summary>
        DriveBurn,

        /// <summary>
        /// DriveCd
        /// </summary>
        DriveCd,

        /// <summary>
        /// DriveCdr
        /// </summary>
        DriveCdr,

        /// <summary>
        /// DriveCdEmpty
        /// </summary>
        DriveCdEmpty,

        /// <summary>
        /// DriveDelete
        /// </summary>
        DriveDelete,

        /// <summary>
        /// DriveDisk
        /// </summary>
        DriveDisk,

        /// <summary>
        /// DriveEdit
        /// </summary>
        DriveEdit,

        /// <summary>
        /// DriveError
        /// </summary>
        DriveError,

        /// <summary>
        /// DriveGo
        /// </summary>
        DriveGo,

        /// <summary>
        /// DriveKey
        /// </summary>
        DriveKey,

        /// <summary>
        /// DriveLink
        /// </summary>
        DriveLink,

        /// <summary>
        /// DriveMagnify
        /// </summary>
        DriveMagnify,

        /// <summary>
        /// DriveNetwork
        /// </summary>
        DriveNetwork,

        /// <summary>
        /// DriveNetworkError
        /// </summary>
        DriveNetworkError,

        /// <summary>
        /// DriveNetworkStop
        /// </summary>
        DriveNetworkStop,

        /// <summary>
        /// DriveRename
        /// </summary>
        DriveRename,

        /// <summary>
        /// DriveUser
        /// </summary>
        DriveUser,

        /// <summary>
        /// DriveWeb
        /// </summary>
        DriveWeb,

        /// <summary>
        /// Dvd
        /// </summary>
        Dvd,

        /// <summary>
        /// DvdAdd
        /// </summary>
        DvdAdd,

        /// <summary>
        /// DvdDelete
        /// </summary>
        DvdDelete,

        /// <summary>
        /// DvdEdit
        /// </summary>
        DvdEdit,

        /// <summary>
        /// DvdError
        /// </summary>
        DvdError,

        /// <summary>
        /// DvdGo
        /// </summary>
        DvdGo,

        /// <summary>
        /// DvdKey
        /// </summary>
        DvdKey,

        /// <summary>
        /// DvdLink
        /// </summary>
        DvdLink,

        /// <summary>
        /// DvdStart
        /// </summary>
        DvdStart,

        /// <summary>
        /// DvdStop
        /// </summary>
        DvdStop,

        /// <summary>
        /// EjectBlue
        /// </summary>
        EjectBlue,

        /// <summary>
        /// EjectGreen
        /// </summary>
        EjectGreen,

        /// <summary>
        /// Email
        /// </summary>
        Email,

        /// <summary>
        /// EmailAdd
        /// </summary>
        EmailAdd,

        /// <summary>
        /// EmailAttach
        /// </summary>
        EmailAttach,

        /// <summary>
        /// EmailDelete
        /// </summary>
        EmailDelete,

        /// <summary>
        /// EmailEdit
        /// </summary>
        EmailEdit,

        /// <summary>
        /// EmailError
        /// </summary>
        EmailError,

        /// <summary>
        /// EmailGo
        /// </summary>
        EmailGo,

        /// <summary>
        /// EmailLink
        /// </summary>
        EmailLink,

        /// <summary>
        /// EmailMagnify
        /// </summary>
        EmailMagnify,

        /// <summary>
        /// EmailOpen
        /// </summary>
        EmailOpen,

        /// <summary>
        /// EmailOpenImage
        /// </summary>
        EmailOpenImage,

        /// <summary>
        /// EmailStar
        /// </summary>
        EmailStar,

        /// <summary>
        /// EmailStart
        /// </summary>
        EmailStart,

        /// <summary>
        /// EmailStop
        /// </summary>
        EmailStop,

        /// <summary>
        /// EmailTransfer
        /// </summary>
        EmailTransfer,

        /// <summary>
        /// EmoticonEvilgrin
        /// </summary>
        EmoticonEvilgrin,

        /// <summary>
        /// EmoticonGrin
        /// </summary>
        EmoticonGrin,

        /// <summary>
        /// EmoticonHappy
        /// </summary>
        EmoticonHappy,

        /// <summary>
        /// EmoticonSmile
        /// </summary>
        EmoticonSmile,

        /// <summary>
        /// EmoticonSurprised
        /// </summary>
        EmoticonSurprised,

        /// <summary>
        /// EmoticonTongue
        /// </summary>
        EmoticonTongue,

        /// <summary>
        /// EmoticonUnhappy
        /// </summary>
        EmoticonUnhappy,

        /// <summary>
        /// EmoticonWaii
        /// </summary>
        EmoticonWaii,

        /// <summary>
        /// EmoticonWink
        /// </summary>
        EmoticonWink,

        /// <summary>
        /// Erase
        /// </summary>
        Erase,

        /// <summary>
        /// Error
        /// </summary>
        Error,

        /// <summary>
        /// ErrorAdd
        /// </summary>
        ErrorAdd,

        /// <summary>
        /// ErrorDelete
        /// </summary>
        ErrorDelete,

        /// <summary>
        /// ErrorGo
        /// </summary>
        ErrorGo,

        /// <summary>
        /// Exclamation
        /// </summary>
        Exclamation,

        /// <summary>
        /// Eye
        /// </summary>
        Eye,

        /// <summary>
        /// Eyes
        /// </summary>
        Eyes,

        /// <summary>
        /// Feed
        /// </summary>
        Feed,

        /// <summary>
        /// FeedAdd
        /// </summary>
        FeedAdd,

        /// <summary>
        /// FeedDelete
        /// </summary>
        FeedDelete,

        /// <summary>
        /// FeedDisk
        /// </summary>
        FeedDisk,

        /// <summary>
        /// FeedEdit
        /// </summary>
        FeedEdit,

        /// <summary>
        /// FeedError
        /// </summary>
        FeedError,

        /// <summary>
        /// FeedGo
        /// </summary>
        FeedGo,

        /// <summary>
        /// FeedKey
        /// </summary>
        FeedKey,

        /// <summary>
        /// FeedLink
        /// </summary>
        FeedLink,

        /// <summary>
        /// FeedMagnify
        /// </summary>
        FeedMagnify,

        /// <summary>
        /// FeedStar
        /// </summary>
        FeedStar,

        /// <summary>
        /// Female
        /// </summary>
        Female,

        /// <summary>
        /// Film
        /// </summary>
        Film,

        /// <summary>
        /// FilmAdd
        /// </summary>
        FilmAdd,

        /// <summary>
        /// FilmDelete
        /// </summary>
        FilmDelete,

        /// <summary>
        /// FilmEdit
        /// </summary>
        FilmEdit,

        /// <summary>
        /// FilmEject
        /// </summary>
        FilmEject,

        /// <summary>
        /// FilmError
        /// </summary>
        FilmError,

        /// <summary>
        /// FilmGo
        /// </summary>
        FilmGo,

        /// <summary>
        /// FilmKey
        /// </summary>
        FilmKey,

        /// <summary>
        /// FilmLink
        /// </summary>
        FilmLink,

        /// <summary>
        /// FilmMagnify
        /// </summary>
        FilmMagnify,

        /// <summary>
        /// FilmSave
        /// </summary>
        FilmSave,

        /// <summary>
        /// FilmStar
        /// </summary>
        FilmStar,

        /// <summary>
        /// FilmStart
        /// </summary>
        FilmStart,

        /// <summary>
        /// FilmStop
        /// </summary>
        FilmStop,

        /// <summary>
        /// Find
        /// </summary>
        Find,

        /// <summary>
        /// FingerPoint
        /// </summary>
        FingerPoint,

        /// <summary>
        /// FlagAd
        /// </summary>
        FlagAd,

        /// <summary>
        /// FlagAe
        /// </summary>
        FlagAe,

        /// <summary>
        /// FlagAf
        /// </summary>
        FlagAf,

        /// <summary>
        /// FlagAg
        /// </summary>
        FlagAg,

        /// <summary>
        /// FlagAi
        /// </summary>
        FlagAi,

        /// <summary>
        /// FlagAl
        /// </summary>
        FlagAl,

        /// <summary>
        /// FlagAm
        /// </summary>
        FlagAm,

        /// <summary>
        /// FlagAn
        /// </summary>
        FlagAn,

        /// <summary>
        /// FlagAo
        /// </summary>
        FlagAo,

        /// <summary>
        /// FlagAr
        /// </summary>
        FlagAr,

        /// <summary>
        /// FlagAs
        /// </summary>
        FlagAs,

        /// <summary>
        /// FlagAt
        /// </summary>
        FlagAt,

        /// <summary>
        /// FlagAu
        /// </summary>
        FlagAu,

        /// <summary>
        /// FlagAw
        /// </summary>
        FlagAw,

        /// <summary>
        /// FlagAx
        /// </summary>
        FlagAx,

        /// <summary>
        /// FlagAz
        /// </summary>
        FlagAz,

        /// <summary>
        /// FlagBa
        /// </summary>
        FlagBa,

        /// <summary>
        /// FlagBb
        /// </summary>
        FlagBb,

        /// <summary>
        /// FlagBd
        /// </summary>
        FlagBd,

        /// <summary>
        /// FlagBe
        /// </summary>
        FlagBe,

        /// <summary>
        /// FlagBf
        /// </summary>
        FlagBf,

        /// <summary>
        /// FlagBg
        /// </summary>
        FlagBg,

        /// <summary>
        /// FlagBh
        /// </summary>
        FlagBh,

        /// <summary>
        /// FlagBi
        /// </summary>
        FlagBi,

        /// <summary>
        /// FlagBj
        /// </summary>
        FlagBj,

        /// <summary>
        /// FlagBlack
        /// </summary>
        FlagBlack,

        /// <summary>
        /// FlagBlue
        /// </summary>
        FlagBlue,

        /// <summary>
        /// FlagBm
        /// </summary>
        FlagBm,

        /// <summary>
        /// FlagBn
        /// </summary>
        FlagBn,

        /// <summary>
        /// FlagBo
        /// </summary>
        FlagBo,

        /// <summary>
        /// FlagBr
        /// </summary>
        FlagBr,

        /// <summary>
        /// FlagBs
        /// </summary>
        FlagBs,

        /// <summary>
        /// FlagBt
        /// </summary>
        FlagBt,

        /// <summary>
        /// FlagBv
        /// </summary>
        FlagBv,

        /// <summary>
        /// FlagBw
        /// </summary>
        FlagBw,

        /// <summary>
        /// FlagBy
        /// </summary>
        FlagBy,

        /// <summary>
        /// FlagBz
        /// </summary>
        FlagBz,

        /// <summary>
        /// FlagCa
        /// </summary>
        FlagCa,

        /// <summary>
        /// FlagCatalonia
        /// </summary>
        FlagCatalonia,

        /// <summary>
        /// FlagCc
        /// </summary>
        FlagCc,

        /// <summary>
        /// FlagCd
        /// </summary>
        FlagCd,

        /// <summary>
        /// FlagCf
        /// </summary>
        FlagCf,

        /// <summary>
        /// FlagCg
        /// </summary>
        FlagCg,

        /// <summary>
        /// FlagCh
        /// </summary>
        FlagCh,

        /// <summary>
        /// FlagChecked
        /// </summary>
        FlagChecked,

        /// <summary>
        /// FlagCi
        /// </summary>
        FlagCi,

        /// <summary>
        /// FlagCk
        /// </summary>
        FlagCk,

        /// <summary>
        /// FlagCl
        /// </summary>
        FlagCl,

        /// <summary>
        /// FlagCm
        /// </summary>
        FlagCm,

        /// <summary>
        /// FlagCn
        /// </summary>
        FlagCn,

        /// <summary>
        /// FlagCo
        /// </summary>
        FlagCo,

        /// <summary>
        /// FlagCr
        /// </summary>
        FlagCr,

        /// <summary>
        /// FlagCs
        /// </summary>
        FlagCs,

        /// <summary>
        /// FlagCu
        /// </summary>
        FlagCu,

        /// <summary>
        /// FlagCv
        /// </summary>
        FlagCv,

        /// <summary>
        /// FlagCx
        /// </summary>
        FlagCx,

        /// <summary>
        /// FlagCy
        /// </summary>
        FlagCy,

        /// <summary>
        /// FlagCz
        /// </summary>
        FlagCz,

        /// <summary>
        /// FlagDe
        /// </summary>
        FlagDe,

        /// <summary>
        /// FlagDj
        /// </summary>
        FlagDj,

        /// <summary>
        /// FlagDk
        /// </summary>
        FlagDk,

        /// <summary>
        /// FlagDm
        /// </summary>
        FlagDm,

        /// <summary>
        /// FlagDo
        /// </summary>
        FlagDo,

        /// <summary>
        /// FlagDz
        /// </summary>
        FlagDz,

        /// <summary>
        /// FlagEc
        /// </summary>
        FlagEc,

        /// <summary>
        /// FlagEe
        /// </summary>
        FlagEe,

        /// <summary>
        /// FlagEg
        /// </summary>
        FlagEg,

        /// <summary>
        /// FlagEh
        /// </summary>
        FlagEh,

        /// <summary>
        /// FlagEngland
        /// </summary>
        FlagEngland,

        /// <summary>
        /// FlagEr
        /// </summary>
        FlagEr,

        /// <summary>
        /// FlagEs
        /// </summary>
        FlagEs,

        /// <summary>
        /// FlagEt
        /// </summary>
        FlagEt,

        /// <summary>
        /// FlagEuropeanunion
        /// </summary>
        FlagEuropeanunion,

        /// <summary>
        /// FlagFam
        /// </summary>
        FlagFam,

        /// <summary>
        /// FlagFi
        /// </summary>
        FlagFi,

        /// <summary>
        /// FlagFj
        /// </summary>
        FlagFj,

        /// <summary>
        /// FlagFk
        /// </summary>
        FlagFk,

        /// <summary>
        /// FlagFm
        /// </summary>
        FlagFm,

        /// <summary>
        /// FlagFo
        /// </summary>
        FlagFo,

        /// <summary>
        /// FlagFr
        /// </summary>
        FlagFr,

        /// <summary>
        /// FlagFrance
        /// </summary>
        FlagFrance,

        /// <summary>
        /// FlagGa
        /// </summary>
        FlagGa,

        /// <summary>
        /// FlagGb
        /// </summary>
        FlagGb,

        /// <summary>
        /// FlagGd
        /// </summary>
        FlagGd,

        /// <summary>
        /// FlagGe
        /// </summary>
        FlagGe,

        /// <summary>
        /// FlagGf
        /// </summary>
        FlagGf,

        /// <summary>
        /// FlagGg
        /// </summary>
        FlagGg,

        /// <summary>
        /// FlagGh
        /// </summary>
        FlagGh,

        /// <summary>
        /// FlagGi
        /// </summary>
        FlagGi,

        /// <summary>
        /// FlagGl
        /// </summary>
        FlagGl,

        /// <summary>
        /// FlagGm
        /// </summary>
        FlagGm,

        /// <summary>
        /// FlagGn
        /// </summary>
        FlagGn,

        /// <summary>
        /// FlagGp
        /// </summary>
        FlagGp,

        /// <summary>
        /// FlagGq
        /// </summary>
        FlagGq,

        /// <summary>
        /// FlagGr
        /// </summary>
        FlagGr,

        /// <summary>
        /// FlagGreen
        /// </summary>
        FlagGreen,

        /// <summary>
        /// FlagGrey
        /// </summary>
        FlagGrey,

        /// <summary>
        /// FlagGs
        /// </summary>
        FlagGs,

        /// <summary>
        /// FlagGt
        /// </summary>
        FlagGt,

        /// <summary>
        /// FlagGu
        /// </summary>
        FlagGu,

        /// <summary>
        /// FlagGw
        /// </summary>
        FlagGw,

        /// <summary>
        /// FlagGy
        /// </summary>
        FlagGy,

        /// <summary>
        /// FlagHk
        /// </summary>
        FlagHk,

        /// <summary>
        /// FlagHm
        /// </summary>
        FlagHm,

        /// <summary>
        /// FlagHn
        /// </summary>
        FlagHn,

        /// <summary>
        /// FlagHr
        /// </summary>
        FlagHr,

        /// <summary>
        /// FlagHt
        /// </summary>
        FlagHt,

        /// <summary>
        /// FlagHu
        /// </summary>
        FlagHu,

        /// <summary>
        /// FlagId
        /// </summary>
        FlagId,

        /// <summary>
        /// FlagIe
        /// </summary>
        FlagIe,

        /// <summary>
        /// FlagIl
        /// </summary>
        FlagIl,

        /// <summary>
        /// FlagIn
        /// </summary>
        FlagIn,

        /// <summary>
        /// FlagIo
        /// </summary>
        FlagIo,

        /// <summary>
        /// FlagIq
        /// </summary>
        FlagIq,

        /// <summary>
        /// FlagIr
        /// </summary>
        FlagIr,

        /// <summary>
        /// FlagIs
        /// </summary>
        FlagIs,

        /// <summary>
        /// FlagIt
        /// </summary>
        FlagIt,

        /// <summary>
        /// FlagJm
        /// </summary>
        FlagJm,

        /// <summary>
        /// FlagJo
        /// </summary>
        FlagJo,

        /// <summary>
        /// FlagJp
        /// </summary>
        FlagJp,

        /// <summary>
        /// FlagKe
        /// </summary>
        FlagKe,

        /// <summary>
        /// FlagKg
        /// </summary>
        FlagKg,

        /// <summary>
        /// FlagKh
        /// </summary>
        FlagKh,

        /// <summary>
        /// FlagKi
        /// </summary>
        FlagKi,

        /// <summary>
        /// FlagKm
        /// </summary>
        FlagKm,

        /// <summary>
        /// FlagKn
        /// </summary>
        FlagKn,

        /// <summary>
        /// FlagKp
        /// </summary>
        FlagKp,

        /// <summary>
        /// FlagKr
        /// </summary>
        FlagKr,

        /// <summary>
        /// FlagKw
        /// </summary>
        FlagKw,

        /// <summary>
        /// FlagKy
        /// </summary>
        FlagKy,

        /// <summary>
        /// FlagKz
        /// </summary>
        FlagKz,

        /// <summary>
        /// FlagLa
        /// </summary>
        FlagLa,

        /// <summary>
        /// FlagLb
        /// </summary>
        FlagLb,

        /// <summary>
        /// FlagLc
        /// </summary>
        FlagLc,

        /// <summary>
        /// FlagLi
        /// </summary>
        FlagLi,

        /// <summary>
        /// FlagLk
        /// </summary>
        FlagLk,

        /// <summary>
        /// FlagLr
        /// </summary>
        FlagLr,

        /// <summary>
        /// FlagLs
        /// </summary>
        FlagLs,

        /// <summary>
        /// FlagLt
        /// </summary>
        FlagLt,

        /// <summary>
        /// FlagLu
        /// </summary>
        FlagLu,

        /// <summary>
        /// FlagLv
        /// </summary>
        FlagLv,

        /// <summary>
        /// FlagLy
        /// </summary>
        FlagLy,

        /// <summary>
        /// FlagMa
        /// </summary>
        FlagMa,

        /// <summary>
        /// FlagMc
        /// </summary>
        FlagMc,

        /// <summary>
        /// FlagMd
        /// </summary>
        FlagMd,

        /// <summary>
        /// FlagMe
        /// </summary>
        FlagMe,

        /// <summary>
        /// FlagMg
        /// </summary>
        FlagMg,

        /// <summary>
        /// FlagMh
        /// </summary>
        FlagMh,

        /// <summary>
        /// FlagMk
        /// </summary>
        FlagMk,

        /// <summary>
        /// FlagMl
        /// </summary>
        FlagMl,

        /// <summary>
        /// FlagMm
        /// </summary>
        FlagMm,

        /// <summary>
        /// FlagMn
        /// </summary>
        FlagMn,

        /// <summary>
        /// FlagMo
        /// </summary>
        FlagMo,

        /// <summary>
        /// FlagMp
        /// </summary>
        FlagMp,

        /// <summary>
        /// FlagMq
        /// </summary>
        FlagMq,

        /// <summary>
        /// FlagMr
        /// </summary>
        FlagMr,

        /// <summary>
        /// FlagMs
        /// </summary>
        FlagMs,

        /// <summary>
        /// FlagMt
        /// </summary>
        FlagMt,

        /// <summary>
        /// FlagMu
        /// </summary>
        FlagMu,

        /// <summary>
        /// FlagMv
        /// </summary>
        FlagMv,

        /// <summary>
        /// FlagMw
        /// </summary>
        FlagMw,

        /// <summary>
        /// FlagMx
        /// </summary>
        FlagMx,

        /// <summary>
        /// FlagMy
        /// </summary>
        FlagMy,

        /// <summary>
        /// FlagMz
        /// </summary>
        FlagMz,

        /// <summary>
        /// FlagNa
        /// </summary>
        FlagNa,

        /// <summary>
        /// FlagNc
        /// </summary>
        FlagNc,

        /// <summary>
        /// FlagNe
        /// </summary>
        FlagNe,

        /// <summary>
        /// FlagNf
        /// </summary>
        FlagNf,

        /// <summary>
        /// FlagNg
        /// </summary>
        FlagNg,

        /// <summary>
        /// FlagNi
        /// </summary>
        FlagNi,

        /// <summary>
        /// FlagNl
        /// </summary>
        FlagNl,

        /// <summary>
        /// FlagNo
        /// </summary>
        FlagNo,

        /// <summary>
        /// FlagNp
        /// </summary>
        FlagNp,

        /// <summary>
        /// FlagNr
        /// </summary>
        FlagNr,

        /// <summary>
        /// FlagNu
        /// </summary>
        FlagNu,

        /// <summary>
        /// FlagNz
        /// </summary>
        FlagNz,

        /// <summary>
        /// FlagOm
        /// </summary>
        FlagOm,

        /// <summary>
        /// FlagOrange
        /// </summary>
        FlagOrange,

        /// <summary>
        /// FlagPa
        /// </summary>
        FlagPa,

        /// <summary>
        /// FlagPe
        /// </summary>
        FlagPe,

        /// <summary>
        /// FlagPf
        /// </summary>
        FlagPf,

        /// <summary>
        /// FlagPg
        /// </summary>
        FlagPg,

        /// <summary>
        /// FlagPh
        /// </summary>
        FlagPh,

        /// <summary>
        /// FlagPink
        /// </summary>
        FlagPink,

        /// <summary>
        /// FlagPk
        /// </summary>
        FlagPk,

        /// <summary>
        /// FlagPl
        /// </summary>
        FlagPl,

        /// <summary>
        /// FlagPm
        /// </summary>
        FlagPm,

        /// <summary>
        /// FlagPn
        /// </summary>
        FlagPn,

        /// <summary>
        /// FlagPr
        /// </summary>
        FlagPr,

        /// <summary>
        /// FlagPs
        /// </summary>
        FlagPs,

        /// <summary>
        /// FlagPt
        /// </summary>
        FlagPt,

        /// <summary>
        /// FlagPurple
        /// </summary>
        FlagPurple,

        /// <summary>
        /// FlagPw
        /// </summary>
        FlagPw,

        /// <summary>
        /// FlagPy
        /// </summary>
        FlagPy,

        /// <summary>
        /// FlagQa
        /// </summary>
        FlagQa,

        /// <summary>
        /// FlagRe
        /// </summary>
        FlagRe,

        /// <summary>
        /// FlagRed
        /// </summary>
        FlagRed,

        /// <summary>
        /// FlagRo
        /// </summary>
        FlagRo,

        /// <summary>
        /// FlagRs
        /// </summary>
        FlagRs,

        /// <summary>
        /// FlagRu
        /// </summary>
        FlagRu,

        /// <summary>
        /// FlagRw
        /// </summary>
        FlagRw,

        /// <summary>
        /// FlagSa
        /// </summary>
        FlagSa,

        /// <summary>
        /// FlagSb
        /// </summary>
        FlagSb,

        /// <summary>
        /// FlagSc
        /// </summary>
        FlagSc,

        /// <summary>
        /// FlagScotland
        /// </summary>
        FlagScotland,

        /// <summary>
        /// FlagSd
        /// </summary>
        FlagSd,

        /// <summary>
        /// FlagSe
        /// </summary>
        FlagSe,

        /// <summary>
        /// FlagSg
        /// </summary>
        FlagSg,

        /// <summary>
        /// FlagSh
        /// </summary>
        FlagSh,

        /// <summary>
        /// FlagSi
        /// </summary>
        FlagSi,

        /// <summary>
        /// FlagSj
        /// </summary>
        FlagSj,

        /// <summary>
        /// FlagSk
        /// </summary>
        FlagSk,

        /// <summary>
        /// FlagSl
        /// </summary>
        FlagSl,

        /// <summary>
        /// FlagSm
        /// </summary>
        FlagSm,

        /// <summary>
        /// FlagSn
        /// </summary>
        FlagSn,

        /// <summary>
        /// FlagSo
        /// </summary>
        FlagSo,

        /// <summary>
        /// FlagSr
        /// </summary>
        FlagSr,

        /// <summary>
        /// FlagSt
        /// </summary>
        FlagSt,

        /// <summary>
        /// FlagSv
        /// </summary>
        FlagSv,

        /// <summary>
        /// FlagSy
        /// </summary>
        FlagSy,

        /// <summary>
        /// FlagSz
        /// </summary>
        FlagSz,

        /// <summary>
        /// FlagTc
        /// </summary>
        FlagTc,

        /// <summary>
        /// FlagTd
        /// </summary>
        FlagTd,

        /// <summary>
        /// FlagTf
        /// </summary>
        FlagTf,

        /// <summary>
        /// FlagTg
        /// </summary>
        FlagTg,

        /// <summary>
        /// FlagTh
        /// </summary>
        FlagTh,

        /// <summary>
        /// FlagTj
        /// </summary>
        FlagTj,

        /// <summary>
        /// FlagTk
        /// </summary>
        FlagTk,

        /// <summary>
        /// FlagTl
        /// </summary>
        FlagTl,

        /// <summary>
        /// FlagTm
        /// </summary>
        FlagTm,

        /// <summary>
        /// FlagTn
        /// </summary>
        FlagTn,

        /// <summary>
        /// FlagTo
        /// </summary>
        FlagTo,

        /// <summary>
        /// FlagTr
        /// </summary>
        FlagTr,

        /// <summary>
        /// FlagTt
        /// </summary>
        FlagTt,

        /// <summary>
        /// FlagTv
        /// </summary>
        FlagTv,

        /// <summary>
        /// FlagTw
        /// </summary>
        FlagTw,

        /// <summary>
        /// FlagTz
        /// </summary>
        FlagTz,

        /// <summary>
        /// FlagUa
        /// </summary>
        FlagUa,

        /// <summary>
        /// FlagUg
        /// </summary>
        FlagUg,

        /// <summary>
        /// FlagUm
        /// </summary>
        FlagUm,

        /// <summary>
        /// FlagUs
        /// </summary>
        FlagUs,

        /// <summary>
        /// FlagUy
        /// </summary>
        FlagUy,

        /// <summary>
        /// FlagUz
        /// </summary>
        FlagUz,

        /// <summary>
        /// FlagVa
        /// </summary>
        FlagVa,

        /// <summary>
        /// FlagVc
        /// </summary>
        FlagVc,

        /// <summary>
        /// FlagVe
        /// </summary>
        FlagVe,

        /// <summary>
        /// FlagVg
        /// </summary>
        FlagVg,

        /// <summary>
        /// FlagVi
        /// </summary>
        FlagVi,

        /// <summary>
        /// FlagVn
        /// </summary>
        FlagVn,

        /// <summary>
        /// FlagVu
        /// </summary>
        FlagVu,

        /// <summary>
        /// FlagWales
        /// </summary>
        FlagWales,

        /// <summary>
        /// FlagWf
        /// </summary>
        FlagWf,

        /// <summary>
        /// FlagWhite
        /// </summary>
        FlagWhite,

        /// <summary>
        /// FlagWs
        /// </summary>
        FlagWs,

        /// <summary>
        /// FlagYe
        /// </summary>
        FlagYe,

        /// <summary>
        /// FlagYellow
        /// </summary>
        FlagYellow,

        /// <summary>
        /// FlagYt
        /// </summary>
        FlagYt,

        /// <summary>
        /// FlagZa
        /// </summary>
        FlagZa,

        /// <summary>
        /// FlagZm
        /// </summary>
        FlagZm,

        /// <summary>
        /// FlagZw
        /// </summary>
        FlagZw,

        /// <summary>
        /// FlowerDaisy
        /// </summary>
        FlowerDaisy,

        /// <summary>
        /// Folder
        /// </summary>
        Folder,

        /// <summary>
        /// FolderAdd
        /// </summary>
        FolderAdd,

        /// <summary>
        /// FolderBell
        /// </summary>
        FolderBell,

        /// <summary>
        /// FolderBookmark
        /// </summary>
        FolderBookmark,

        /// <summary>
        /// FolderBrick
        /// </summary>
        FolderBrick,

        /// <summary>
        /// FolderBug
        /// </summary>
        FolderBug,

        /// <summary>
        /// FolderCamera
        /// </summary>
        FolderCamera,

        /// <summary>
        /// FolderConnect
        /// </summary>
        FolderConnect,

        /// <summary>
        /// FolderDatabase
        /// </summary>
        FolderDatabase,

        /// <summary>
        /// FolderDelete
        /// </summary>
        FolderDelete,

        /// <summary>
        /// FolderEdit
        /// </summary>
        FolderEdit,

        /// <summary>
        /// FolderError
        /// </summary>
        FolderError,

        /// <summary>
        /// FolderExplore
        /// </summary>
        FolderExplore,

        /// <summary>
        /// FolderFeed
        /// </summary>
        FolderFeed,

        /// <summary>
        /// FolderFilm
        /// </summary>
        FolderFilm,

        /// <summary>
        /// FolderFind
        /// </summary>
        FolderFind,

        /// <summary>
        /// FolderFont
        /// </summary>
        FolderFont,

        /// <summary>
        /// FolderGo
        /// </summary>
        FolderGo,

        /// <summary>
        /// FolderHeart
        /// </summary>
        FolderHeart,

        /// <summary>
        /// FolderHome
        /// </summary>
        FolderHome,

        /// <summary>
        /// FolderImage
        /// </summary>
        FolderImage,

        /// <summary>
        /// FolderKey
        /// </summary>
        FolderKey,

        /// <summary>
        /// FolderLightbulb
        /// </summary>
        FolderLightbulb,

        /// <summary>
        /// FolderLink
        /// </summary>
        FolderLink,

        /// <summary>
        /// FolderMagnify
        /// </summary>
        FolderMagnify,

        /// <summary>
        /// FolderPage
        /// </summary>
        FolderPage,

        /// <summary>
        /// FolderPageWhite
        /// </summary>
        FolderPageWhite,

        /// <summary>
        /// FolderPalette
        /// </summary>
        FolderPalette,

        /// <summary>
        /// FolderPicture
        /// </summary>
        FolderPicture,

        /// <summary>
        /// FolderStar
        /// </summary>
        FolderStar,

        /// <summary>
        /// FolderTable
        /// </summary>
        FolderTable,

        /// <summary>
        /// FolderUp
        /// </summary>
        FolderUp,

        /// <summary>
        /// FolderUser
        /// </summary>
        FolderUser,

        /// <summary>
        /// FolderWrench
        /// </summary>
        FolderWrench,

        /// <summary>
        /// Font
        /// </summary>
        Font,

        /// <summary>
        /// FontAdd
        /// </summary>
        FontAdd,

        /// <summary>
        /// FontColor
        /// </summary>
        FontColor,

        /// <summary>
        /// FontDelete
        /// </summary>
        FontDelete,

        /// <summary>
        /// FontGo
        /// </summary>
        FontGo,

        /// <summary>
        /// FontLarger
        /// </summary>
        FontLarger,

        /// <summary>
        /// FontSmaller
        /// </summary>
        FontSmaller,

        /// <summary>
        /// ForwardBlue
        /// </summary>
        ForwardBlue,

        /// <summary>
        /// ForwardGreen
        /// </summary>
        ForwardGreen,

        /// <summary>
        /// Group
        /// </summary>
        Group,

        /// <summary>
        /// GroupAdd
        /// </summary>
        GroupAdd,

        /// <summary>
        /// GroupDelete
        /// </summary>
        GroupDelete,

        /// <summary>
        /// GroupEdit
        /// </summary>
        GroupEdit,

        /// <summary>
        /// GroupError
        /// </summary>
        GroupError,

        /// <summary>
        /// GroupGear
        /// </summary>
        GroupGear,

        /// <summary>
        /// GroupGo
        /// </summary>
        GroupGo,

        /// <summary>
        /// GroupKey
        /// </summary>
        GroupKey,

        /// <summary>
        /// GroupLink
        /// </summary>
        GroupLink,

        /// <summary>
        /// Heart
        /// </summary>
        Heart,

        /// <summary>
        /// HeartAdd
        /// </summary>
        HeartAdd,

        /// <summary>
        /// HeartBroken
        /// </summary>
        HeartBroken,

        /// <summary>
        /// HeartConnect
        /// </summary>
        HeartConnect,

        /// <summary>
        /// HeartDelete
        /// </summary>
        HeartDelete,

        /// <summary>
        /// Help
        /// </summary>
        Help,

        /// <summary>
        /// Hourglass
        /// </summary>
        Hourglass,

        /// <summary>
        /// HourglassAdd
        /// </summary>
        HourglassAdd,

        /// <summary>
        /// HourglassDelete
        /// </summary>
        HourglassDelete,

        /// <summary>
        /// HourglassGo
        /// </summary>
        HourglassGo,

        /// <summary>
        /// HourglassLink
        /// </summary>
        HourglassLink,

        /// <summary>
        /// House
        /// </summary>
        House,

        /// <summary>
        /// HouseConnect
        /// </summary>
        HouseConnect,

        /// <summary>
        /// HouseGo
        /// </summary>
        HouseGo,

        /// <summary>
        /// HouseKey
        /// </summary>
        HouseKey,

        /// <summary>
        /// HouseLink
        /// </summary>
        HouseLink,

        /// <summary>
        /// HouseStar
        /// </summary>
        HouseStar,

        /// <summary>
        /// Html
        /// </summary>
        Html,

        /// <summary>
        /// HtmlAdd
        /// </summary>
        HtmlAdd,

        /// <summary>
        /// HtmlDelete
        /// </summary>
        HtmlDelete,

        /// <summary>
        /// HtmlError
        /// </summary>
        HtmlError,

        /// <summary>
        /// HtmlGo
        /// </summary>
        HtmlGo,

        /// <summary>
        /// HtmlValid
        /// </summary>
        HtmlValid,

        /// <summary>
        /// Image
        /// </summary>
        Image,

        /// <summary>
        /// Images
        /// </summary>
        Images,

        /// <summary>
        /// ImageAdd
        /// </summary>
        ImageAdd,

        /// <summary>
        /// ImageDelete
        /// </summary>
        ImageDelete,

        /// <summary>
        /// ImageEdit
        /// </summary>
        ImageEdit,

        /// <summary>
        /// ImageLink
        /// </summary>
        ImageLink,

        /// <summary>
        /// ImageMagnify
        /// </summary>
        ImageMagnify,

        /// <summary>
        /// ImageStar
        /// </summary>
        ImageStar,

        /// <summary>
        /// Information
        /// </summary>
        Information,

        /// <summary>
        /// Ipod
        /// </summary>
        Ipod,

        /// <summary>
        /// IpodCast
        /// </summary>
        IpodCast,

        /// <summary>
        /// IpodCastAdd
        /// </summary>
        IpodCastAdd,

        /// <summary>
        /// IpodCastDelete
        /// </summary>
        IpodCastDelete,

        /// <summary>
        /// IpodConnect
        /// </summary>
        IpodConnect,

        /// <summary>
        /// IpodNano
        /// </summary>
        IpodNano,

        /// <summary>
        /// IpodNanoConnect
        /// </summary>
        IpodNanoConnect,

        /// <summary>
        /// IpodSound
        /// </summary>
        IpodSound,

        /// <summary>
        /// Joystick
        /// </summary>
        Joystick,

        /// <summary>
        /// JoystickAdd
        /// </summary>
        JoystickAdd,

        /// <summary>
        /// JoystickConnect
        /// </summary>
        JoystickConnect,

        /// <summary>
        /// JoystickDelete
        /// </summary>
        JoystickDelete,

        /// <summary>
        /// JoystickError
        /// </summary>
        JoystickError,

        /// <summary>
        /// Key
        /// </summary>
        Key,

        /// <summary>
        /// Keyboard
        /// </summary>
        Keyboard,

        /// <summary>
        /// KeyboardAdd
        /// </summary>
        KeyboardAdd,

        /// <summary>
        /// KeyboardConnect
        /// </summary>
        KeyboardConnect,

        /// <summary>
        /// KeyboardDelete
        /// </summary>
        KeyboardDelete,

        /// <summary>
        /// KeyboardMagnify
        /// </summary>
        KeyboardMagnify,

        /// <summary>
        /// KeyAdd
        /// </summary>
        KeyAdd,

        /// <summary>
        /// KeyDelete
        /// </summary>
        KeyDelete,

        /// <summary>
        /// KeyGo
        /// </summary>
        KeyGo,

        /// <summary>
        /// KeyStart
        /// </summary>
        KeyStart,

        /// <summary>
        /// KeyStop
        /// </summary>
        KeyStop,

        /// <summary>
        /// Laptop
        /// </summary>
        Laptop,

        /// <summary>
        /// LaptopAdd
        /// </summary>
        LaptopAdd,

        /// <summary>
        /// LaptopConnect
        /// </summary>
        LaptopConnect,

        /// <summary>
        /// LaptopDelete
        /// </summary>
        LaptopDelete,

        /// <summary>
        /// LaptopDisk
        /// </summary>
        LaptopDisk,

        /// <summary>
        /// LaptopEdit
        /// </summary>
        LaptopEdit,

        /// <summary>
        /// LaptopError
        /// </summary>
        LaptopError,

        /// <summary>
        /// LaptopGo
        /// </summary>
        LaptopGo,

        /// <summary>
        /// LaptopKey
        /// </summary>
        LaptopKey,

        /// <summary>
        /// LaptopLink
        /// </summary>
        LaptopLink,

        /// <summary>
        /// LaptopMagnify
        /// </summary>
        LaptopMagnify,

        /// <summary>
        /// LaptopStart
        /// </summary>
        LaptopStart,

        /// <summary>
        /// LaptopStop
        /// </summary>
        LaptopStop,

        /// <summary>
        /// LaptopWrench
        /// </summary>
        LaptopWrench,

        /// <summary>
        /// Layers
        /// </summary>
        Layers,

        /// <summary>
        /// Layout
        /// </summary>
        Layout,

        /// <summary>
        /// LayoutAdd
        /// </summary>
        LayoutAdd,

        /// <summary>
        /// LayoutContent
        /// </summary>
        LayoutContent,

        /// <summary>
        /// LayoutDelete
        /// </summary>
        LayoutDelete,

        /// <summary>
        /// LayoutEdit
        /// </summary>
        LayoutEdit,

        /// <summary>
        /// LayoutError
        /// </summary>
        LayoutError,

        /// <summary>
        /// LayoutHeader
        /// </summary>
        LayoutHeader,

        /// <summary>
        /// LayoutKey
        /// </summary>
        LayoutKey,

        /// <summary>
        /// LayoutLightning
        /// </summary>
        LayoutLightning,

        /// <summary>
        /// LayoutLink
        /// </summary>
        LayoutLink,

        /// <summary>
        /// LayoutSidebar
        /// </summary>
        LayoutSidebar,

        /// <summary>
        /// Lightbulb
        /// </summary>
        Lightbulb,

        /// <summary>
        /// LightbulbAdd
        /// </summary>
        LightbulbAdd,

        /// <summary>
        /// LightbulbDelete
        /// </summary>
        LightbulbDelete,

        /// <summary>
        /// LightbulbOff
        /// </summary>
        LightbulbOff,

        /// <summary>
        /// Lightning
        /// </summary>
        Lightning,

        /// <summary>
        /// LightningAdd
        /// </summary>
        LightningAdd,

        /// <summary>
        /// LightningDelete
        /// </summary>
        LightningDelete,

        /// <summary>
        /// LightningGo
        /// </summary>
        LightningGo,

        /// <summary>
        /// Link
        /// </summary>
        Link,

        /// <summary>
        /// LinkAdd
        /// </summary>
        LinkAdd,

        /// <summary>
        /// LinkBreak
        /// </summary>
        LinkBreak,

        /// <summary>
        /// LinkDelete
        /// </summary>
        LinkDelete,

        /// <summary>
        /// LinkEdit
        /// </summary>
        LinkEdit,

        /// <summary>
        /// LinkError
        /// </summary>
        LinkError,

        /// <summary>
        /// LinkGo
        /// </summary>
        LinkGo,

        /// <summary>
        /// Lock
        /// </summary>
        Lock,

        /// <summary>
        /// LockAdd
        /// </summary>
        LockAdd,

        /// <summary>
        /// LockBreak
        /// </summary>
        LockBreak,

        /// <summary>
        /// LockDelete
        /// </summary>
        LockDelete,

        /// <summary>
        /// LockEdit
        /// </summary>
        LockEdit,

        /// <summary>
        /// LockGo
        /// </summary>
        LockGo,

        /// <summary>
        /// LockKey
        /// </summary>
        LockKey,

        /// <summary>
        /// LockOpen
        /// </summary>
        LockOpen,

        /// <summary>
        /// LockStart
        /// </summary>
        LockStart,

        /// <summary>
        /// LockStop
        /// </summary>
        LockStop,

        /// <summary>
        /// Lorry
        /// </summary>
        Lorry,

        /// <summary>
        /// LorryAdd
        /// </summary>
        LorryAdd,

        /// <summary>
        /// LorryDelete
        /// </summary>
        LorryDelete,

        /// <summary>
        /// LorryError
        /// </summary>
        LorryError,

        /// <summary>
        /// LorryFlatbed
        /// </summary>
        LorryFlatbed,

        /// <summary>
        /// LorryGo
        /// </summary>
        LorryGo,

        /// <summary>
        /// LorryLink
        /// </summary>
        LorryLink,

        /// <summary>
        /// LorryStart
        /// </summary>
        LorryStart,

        /// <summary>
        /// LorryStop
        /// </summary>
        LorryStop,

        /// <summary>
        /// MagifierZoomOut
        /// </summary>
        MagifierZoomOut,

        /// <summary>
        /// Magnifier
        /// </summary>
        Magnifier,

        /// <summary>
        /// MagnifierZoomIn
        /// </summary>
        MagnifierZoomIn,

        /// <summary>
        /// Mail
        /// </summary>
        Mail,

        /// <summary>
        /// Male
        /// </summary>
        Male,

        /// <summary>
        /// Map
        /// </summary>
        Map,

        /// <summary>
        /// MapAdd
        /// </summary>
        MapAdd,

        /// <summary>
        /// MapClipboard
        /// </summary>
        MapClipboard,

        /// <summary>
        /// MapCursor
        /// </summary>
        MapCursor,

        /// <summary>
        /// MapDelete
        /// </summary>
        MapDelete,

        /// <summary>
        /// MapEdit
        /// </summary>
        MapEdit,

        /// <summary>
        /// MapError
        /// </summary>
        MapError,

        /// <summary>
        /// MapGo
        /// </summary>
        MapGo,

        /// <summary>
        /// MapLink
        /// </summary>
        MapLink,

        /// <summary>
        /// MapMagnify
        /// </summary>
        MapMagnify,

        /// <summary>
        /// MapStart
        /// </summary>
        MapStart,

        /// <summary>
        /// MapStop
        /// </summary>
        MapStop,

        /// <summary>
        /// MedalBronze1
        /// </summary>
        MedalBronze1,

        /// <summary>
        /// MedalBronze2
        /// </summary>
        MedalBronze2,

        /// <summary>
        /// MedalBronze3
        /// </summary>
        MedalBronze3,

        /// <summary>
        /// MedalBronzeAdd
        /// </summary>
        MedalBronzeAdd,

        /// <summary>
        /// MedalBronzeDelete
        /// </summary>
        MedalBronzeDelete,

        /// <summary>
        /// MedalGold1
        /// </summary>
        MedalGold1,

        /// <summary>
        /// MedalGold2
        /// </summary>
        MedalGold2,

        /// <summary>
        /// MedalGold3
        /// </summary>
        MedalGold3,

        /// <summary>
        /// MedalGoldAdd
        /// </summary>
        MedalGoldAdd,

        /// <summary>
        /// MedalGoldDelete
        /// </summary>
        MedalGoldDelete,

        /// <summary>
        /// MedalSilver1
        /// </summary>
        MedalSilver1,

        /// <summary>
        /// MedalSilver2
        /// </summary>
        MedalSilver2,

        /// <summary>
        /// MedalSilver3
        /// </summary>
        MedalSilver3,

        /// <summary>
        /// MedalSilverAdd
        /// </summary>
        MedalSilverAdd,

        /// <summary>
        /// MedalSilverDelete
        /// </summary>
        MedalSilverDelete,

        /// <summary>
        /// Money
        /// </summary>
        Money,

        /// <summary>
        /// MoneyAdd
        /// </summary>
        MoneyAdd,

        /// <summary>
        /// MoneyDelete
        /// </summary>
        MoneyDelete,

        /// <summary>
        /// MoneyDollar
        /// </summary>
        MoneyDollar,

        /// <summary>
        /// MoneyEuro
        /// </summary>
        MoneyEuro,

        /// <summary>
        /// MoneyPound
        /// </summary>
        MoneyPound,

        /// <summary>
        /// MoneyYen
        /// </summary>
        MoneyYen,

        /// <summary>
        /// Monitor
        /// </summary>
        Monitor,

        /// <summary>
        /// MonitorAdd
        /// </summary>
        MonitorAdd,

        /// <summary>
        /// MonitorDelete
        /// </summary>
        MonitorDelete,

        /// <summary>
        /// MonitorEdit
        /// </summary>
        MonitorEdit,

        /// <summary>
        /// MonitorError
        /// </summary>
        MonitorError,

        /// <summary>
        /// MonitorGo
        /// </summary>
        MonitorGo,

        /// <summary>
        /// MonitorKey
        /// </summary>
        MonitorKey,

        /// <summary>
        /// MonitorLightning
        /// </summary>
        MonitorLightning,

        /// <summary>
        /// MonitorLink
        /// </summary>
        MonitorLink,

        /// <summary>
        /// MoonFull
        /// </summary>
        MoonFull,

        /// <summary>
        /// Mouse
        /// </summary>
        Mouse,

        /// <summary>
        /// MouseAdd
        /// </summary>
        MouseAdd,

        /// <summary>
        /// MouseDelete
        /// </summary>
        MouseDelete,

        /// <summary>
        /// MouseError
        /// </summary>
        MouseError,

        /// <summary>
        /// Music
        /// </summary>
        Music,

        /// <summary>
        /// MusicNote
        /// </summary>
        MusicNote,

        /// <summary>
        /// Neighbourhood
        /// </summary>
        Neighbourhood,

        /// <summary>
        /// New
        /// </summary>
        New,

        /// <summary>
        /// Newspaper
        /// </summary>
        Newspaper,

        /// <summary>
        /// NewspaperAdd
        /// </summary>
        NewspaperAdd,

        /// <summary>
        /// NewspaperDelete
        /// </summary>
        NewspaperDelete,

        /// <summary>
        /// NewspaperGo
        /// </summary>
        NewspaperGo,

        /// <summary>
        /// NewspaperLink
        /// </summary>
        NewspaperLink,

        /// <summary>
        /// NewBlue
        /// </summary>
        NewBlue,

        /// <summary>
        /// NewRed
        /// </summary>
        NewRed,

        /// <summary>
        /// NextBlue
        /// </summary>
        NextBlue,

        /// <summary>
        /// NextGreen
        /// </summary>
        NextGreen,

        /// <summary>
        /// Note
        /// </summary>
        Note,

        /// <summary>
        /// NoteAdd
        /// </summary>
        NoteAdd,

        /// <summary>
        /// NoteDelete
        /// </summary>
        NoteDelete,

        /// <summary>
        /// NoteEdit
        /// </summary>
        NoteEdit,

        /// <summary>
        /// NoteError
        /// </summary>
        NoteError,

        /// <summary>
        /// NoteGo
        /// </summary>
        NoteGo,

        /// <summary>
        /// Outline
        /// </summary>
        Outline,

        /// <summary>
        /// Overlays
        /// </summary>
        Overlays,

        /// <summary>
        /// Package
        /// </summary>
        Package,

        /// <summary>
        /// PackageAdd
        /// </summary>
        PackageAdd,

        /// <summary>
        /// PackageDelete
        /// </summary>
        PackageDelete,

        /// <summary>
        /// PackageDown
        /// </summary>
        PackageDown,

        /// <summary>
        /// PackageGo
        /// </summary>
        PackageGo,

        /// <summary>
        /// PackageGreen
        /// </summary>
        PackageGreen,

        /// <summary>
        /// PackageIn
        /// </summary>
        PackageIn,

        /// <summary>
        /// PackageLink
        /// </summary>
        PackageLink,

        /// <summary>
        /// PackageSe
        /// </summary>
        PackageSe,

        /// <summary>
        /// PackageStart
        /// </summary>
        PackageStart,

        /// <summary>
        /// PackageStop
        /// </summary>
        PackageStop,

        /// <summary>
        /// PackageWhite
        /// </summary>
        PackageWhite,

        /// <summary>
        /// Page
        /// </summary>
        Page,

        /// <summary>
        /// PageAdd
        /// </summary>
        PageAdd,

        /// <summary>
        /// PageAttach
        /// </summary>
        PageAttach,

        /// <summary>
        /// PageBack
        /// </summary>
        PageBack,

        /// <summary>
        /// PageBreak
        /// </summary>
        PageBreak,

        /// <summary>
        /// PageBreakInsert
        /// </summary>
        PageBreakInsert,

        /// <summary>
        /// PageCancel
        /// </summary>
        PageCancel,

        /// <summary>
        /// PageCode
        /// </summary>
        PageCode,

        /// <summary>
        /// PageCopy
        /// </summary>
        PageCopy,

        /// <summary>
        /// PageDelete
        /// </summary>
        PageDelete,

        /// <summary>
        /// PageEdit
        /// </summary>
        PageEdit,

        /// <summary>
        /// PageError
        /// </summary>
        PageError,

        /// <summary>
        /// PageExcel
        /// </summary>
        PageExcel,

        /// <summary>
        /// PageFind
        /// </summary>
        PageFind,

        /// <summary>
        /// PageForward
        /// </summary>
        PageForward,

        /// <summary>
        /// PageGear
        /// </summary>
        PageGear,

        /// <summary>
        /// PageGo
        /// </summary>
        PageGo,

        /// <summary>
        /// PageGreen
        /// </summary>
        PageGreen,

        /// <summary>
        /// PageHeaderFooter
        /// </summary>
        PageHeaderFooter,

        /// <summary>
        /// PageKey
        /// </summary>
        PageKey,

        /// <summary>
        /// PageLandscape
        /// </summary>
        PageLandscape,

        /// <summary>
        /// PageLandscapeShot
        /// </summary>
        PageLandscapeShot,

        /// <summary>
        /// PageLightning
        /// </summary>
        PageLightning,

        /// <summary>
        /// PageLink
        /// </summary>
        PageLink,

        /// <summary>
        /// PageMagnify
        /// </summary>
        PageMagnify,

        /// <summary>
        /// PagePaintbrush
        /// </summary>
        PagePaintbrush,

        /// <summary>
        /// PagePaste
        /// </summary>
        PagePaste,

        /// <summary>
        /// PagePortrait
        /// </summary>
        PagePortrait,

        /// <summary>
        /// PagePortraitShot
        /// </summary>
        PagePortraitShot,

        /// <summary>
        /// PageRed
        /// </summary>
        PageRed,

        /// <summary>
        /// PageRefresh
        /// </summary>
        PageRefresh,

        /// <summary>
        /// PageSave
        /// </summary>
        PageSave,

        /// <summary>
        /// PageWhite
        /// </summary>
        PageWhite,

        /// <summary>
        /// PageWhiteAcrobat
        /// </summary>
        PageWhiteAcrobat,

        /// <summary>
        /// PageWhiteActionscript
        /// </summary>
        PageWhiteActionscript,

        /// <summary>
        /// PageWhiteAdd
        /// </summary>
        PageWhiteAdd,

        /// <summary>
        /// PageWhiteBreak
        /// </summary>
        PageWhiteBreak,

        /// <summary>
        /// PageWhiteC
        /// </summary>
        PageWhiteC,

        /// <summary>
        /// PageWhiteCamera
        /// </summary>
        PageWhiteCamera,

        /// <summary>
        /// PageWhiteCd
        /// </summary>
        PageWhiteCd,

        /// <summary>
        /// PageWhiteCdr
        /// </summary>
        PageWhiteCdr,

        /// <summary>
        /// PageWhiteCode
        /// </summary>
        PageWhiteCode,

        /// <summary>
        /// PageWhiteCodeRed
        /// </summary>
        PageWhiteCodeRed,

        /// <summary>
        /// PageWhiteColdfusion
        /// </summary>
        PageWhiteColdfusion,

        /// <summary>
        /// PageWhiteCompressed
        /// </summary>
        PageWhiteCompressed,

        /// <summary>
        /// PageWhiteConnect
        /// </summary>
        PageWhiteConnect,

        /// <summary>
        /// PageWhiteCopy
        /// </summary>
        PageWhiteCopy,

        /// <summary>
        /// PageWhiteCplusplus
        /// </summary>
        PageWhiteCplusplus,

        /// <summary>
        /// PageWhiteCsharp
        /// </summary>
        PageWhiteCsharp,

        /// <summary>
        /// PageWhiteCup
        /// </summary>
        PageWhiteCup,

        /// <summary>
        /// PageWhiteDatabase
        /// </summary>
        PageWhiteDatabase,

        /// <summary>
        /// PageWhiteDatabaseYellow
        /// </summary>
        PageWhiteDatabaseYellow,

        /// <summary>
        /// PageWhiteDelete
        /// </summary>
        PageWhiteDelete,

        /// <summary>
        /// PageWhiteDvd
        /// </summary>
        PageWhiteDvd,

        /// <summary>
        /// PageWhiteEdit
        /// </summary>
        PageWhiteEdit,

        /// <summary>
        /// PageWhiteError
        /// </summary>
        PageWhiteError,

        /// <summary>
        /// PageWhiteExcel
        /// </summary>
        PageWhiteExcel,

        /// <summary>
        /// PageWhiteFind
        /// </summary>
        PageWhiteFind,

        /// <summary>
        /// PageWhiteFlash
        /// </summary>
        PageWhiteFlash,

        /// <summary>
        /// PageWhiteFont
        /// </summary>
        PageWhiteFont,

        /// <summary>
        /// PageWhiteFreehand
        /// </summary>
        PageWhiteFreehand,

        /// <summary>
        /// PageWhiteGear
        /// </summary>
        PageWhiteGear,

        /// <summary>
        /// PageWhiteGet
        /// </summary>
        PageWhiteGet,

        /// <summary>
        /// PageWhiteGo
        /// </summary>
        PageWhiteGo,

        /// <summary>
        /// PageWhiteH
        /// </summary>
        PageWhiteH,

        /// <summary>
        /// PageWhiteHorizontal
        /// </summary>
        PageWhiteHorizontal,

        /// <summary>
        /// PageWhiteKey
        /// </summary>
        PageWhiteKey,

        /// <summary>
        /// PageWhiteLightning
        /// </summary>
        PageWhiteLightning,

        /// <summary>
        /// PageWhiteLink
        /// </summary>
        PageWhiteLink,

        /// <summary>
        /// PageWhiteMagnify
        /// </summary>
        PageWhiteMagnify,

        /// <summary>
        /// PageWhiteMedal
        /// </summary>
        PageWhiteMedal,

        /// <summary>
        /// PageWhiteOffice
        /// </summary>
        PageWhiteOffice,

        /// <summary>
        /// PageWhitePaint
        /// </summary>
        PageWhitePaint,

        /// <summary>
        /// PageWhitePaintbrush
        /// </summary>
        PageWhitePaintbrush,

        /// <summary>
        /// PageWhitePaint2
        /// </summary>
        PageWhitePaint2,

        /// <summary>
        /// PageWhitePaste
        /// </summary>
        PageWhitePaste,

        /// <summary>
        /// PageWhitePasteTable
        /// </summary>
        PageWhitePasteTable,

        /// <summary>
        /// PageWhitePhp
        /// </summary>
        PageWhitePhp,

        /// <summary>
        /// PageWhitePicture
        /// </summary>
        PageWhitePicture,

        /// <summary>
        /// PageWhitePowerpoint
        /// </summary>
        PageWhitePowerpoint,

        /// <summary>
        /// PageWhitePut
        /// </summary>
        PageWhitePut,

        /// <summary>
        /// PageWhiteRefresh
        /// </summary>
        PageWhiteRefresh,

        /// <summary>
        /// PageWhiteRuby
        /// </summary>
        PageWhiteRuby,

        /// <summary>
        /// PageWhiteSideBySide
        /// </summary>
        PageWhiteSideBySide,

        /// <summary>
        /// PageWhiteStack
        /// </summary>
        PageWhiteStack,

        /// <summary>
        /// PageWhiteStar
        /// </summary>
        PageWhiteStar,

        /// <summary>
        /// PageWhiteSwoosh
        /// </summary>
        PageWhiteSwoosh,

        /// <summary>
        /// PageWhiteText
        /// </summary>
        PageWhiteText,

        /// <summary>
        /// PageWhiteTextWidth
        /// </summary>
        PageWhiteTextWidth,

        /// <summary>
        /// PageWhiteTux
        /// </summary>
        PageWhiteTux,

        /// <summary>
        /// PageWhiteVector
        /// </summary>
        PageWhiteVector,

        /// <summary>
        /// PageWhiteVisualstudio
        /// </summary>
        PageWhiteVisualstudio,

        /// <summary>
        /// PageWhiteWidth
        /// </summary>
        PageWhiteWidth,

        /// <summary>
        /// PageWhiteWord
        /// </summary>
        PageWhiteWord,

        /// <summary>
        /// PageWhiteWorld
        /// </summary>
        PageWhiteWorld,

        /// <summary>
        /// PageWhiteWrench
        /// </summary>
        PageWhiteWrench,

        /// <summary>
        /// PageWhiteZip
        /// </summary>
        PageWhiteZip,

        /// <summary>
        /// PageWord
        /// </summary>
        PageWord,

        /// <summary>
        /// PageWorld
        /// </summary>
        PageWorld,

        /// <summary>
        /// Paint
        /// </summary>
        Paint,

        /// <summary>
        /// Paintbrush
        /// </summary>
        Paintbrush,

        /// <summary>
        /// PaintbrushColor
        /// </summary>
        PaintbrushColor,

        /// <summary>
        /// Paintcan
        /// </summary>
        Paintcan,

        /// <summary>
        /// PaintcanRed
        /// </summary>
        PaintcanRed,

        /// <summary>
        /// PaintCanBrush
        /// </summary>
        PaintCanBrush,

        /// <summary>
        /// Palette
        /// </summary>
        Palette,

        /// <summary>
        /// PastePlain
        /// </summary>
        PastePlain,

        /// <summary>
        /// PasteWord
        /// </summary>
        PasteWord,

        /// <summary>
        /// PauseBlue
        /// </summary>
        PauseBlue,

        /// <summary>
        /// PauseGreen
        /// </summary>
        PauseGreen,

        /// <summary>
        /// PauseRecord
        /// </summary>
        PauseRecord,

        /// <summary>
        /// Pencil
        /// </summary>
        Pencil,

        /// <summary>
        /// PencilAdd
        /// </summary>
        PencilAdd,

        /// <summary>
        /// PencilDelete
        /// </summary>
        PencilDelete,

        /// <summary>
        /// PencilGo
        /// </summary>
        PencilGo,

        /// <summary>
        /// Phone
        /// </summary>
        Phone,

        /// <summary>
        /// PhoneAdd
        /// </summary>
        PhoneAdd,

        /// <summary>
        /// PhoneDelete
        /// </summary>
        PhoneDelete,

        /// <summary>
        /// PhoneEdit
        /// </summary>
        PhoneEdit,

        /// <summary>
        /// PhoneError
        /// </summary>
        PhoneError,

        /// <summary>
        /// PhoneGo
        /// </summary>
        PhoneGo,

        /// <summary>
        /// PhoneKey
        /// </summary>
        PhoneKey,

        /// <summary>
        /// PhoneLink
        /// </summary>
        PhoneLink,

        /// <summary>
        /// PhoneSound
        /// </summary>
        PhoneSound,

        /// <summary>
        /// PhoneStart
        /// </summary>
        PhoneStart,

        /// <summary>
        /// PhoneStop
        /// </summary>
        PhoneStop,

        /// <summary>
        /// Photo
        /// </summary>
        Photo,

        /// <summary>
        /// Photos
        /// </summary>
        Photos,

        /// <summary>
        /// PhotoAdd
        /// </summary>
        PhotoAdd,

        /// <summary>
        /// PhotoDelete
        /// </summary>
        PhotoDelete,

        /// <summary>
        /// PhotoEdit
        /// </summary>
        PhotoEdit,

        /// <summary>
        /// PhotoLink
        /// </summary>
        PhotoLink,

        /// <summary>
        /// PhotoPaint
        /// </summary>
        PhotoPaint,

        /// <summary>
        /// Picture
        /// </summary>
        Picture,

        /// <summary>
        /// Pictures
        /// </summary>
        Pictures,

        /// <summary>
        /// PicturesThumbs
        /// </summary>
        PicturesThumbs,

        /// <summary>
        /// PictureAdd
        /// </summary>
        PictureAdd,

        /// <summary>
        /// PictureClipboard
        /// </summary>
        PictureClipboard,

        /// <summary>
        /// PictureDelete
        /// </summary>
        PictureDelete,

        /// <summary>
        /// PictureEdit
        /// </summary>
        PictureEdit,

        /// <summary>
        /// PictureEmpty
        /// </summary>
        PictureEmpty,

        /// <summary>
        /// PictureError
        /// </summary>
        PictureError,

        /// <summary>
        /// PictureGo
        /// </summary>
        PictureGo,

        /// <summary>
        /// PictureKey
        /// </summary>
        PictureKey,

        /// <summary>
        /// PictureLink
        /// </summary>
        PictureLink,

        /// <summary>
        /// PictureSave
        /// </summary>
        PictureSave,

        /// <summary>
        /// Pilcrow
        /// </summary>
        Pilcrow,

        /// <summary>
        /// Pill
        /// </summary>
        Pill,

        /// <summary>
        /// PillAdd
        /// </summary>
        PillAdd,

        /// <summary>
        /// PillDelete
        /// </summary>
        PillDelete,

        /// <summary>
        /// PillError
        /// </summary>
        PillError,

        /// <summary>
        /// PillGo
        /// </summary>
        PillGo,

        /// <summary>
        /// PlayBlue
        /// </summary>
        PlayBlue,

        /// <summary>
        /// PlayGreen
        /// </summary>
        PlayGreen,

        /// <summary>
        /// Plugin
        /// </summary>
        Plugin,

        /// <summary>
        /// PluginAdd
        /// </summary>
        PluginAdd,

        /// <summary>
        /// PluginDelete
        /// </summary>
        PluginDelete,

        /// <summary>
        /// PluginDisabled
        /// </summary>
        PluginDisabled,

        /// <summary>
        /// PluginEdit
        /// </summary>
        PluginEdit,

        /// <summary>
        /// PluginError
        /// </summary>
        PluginError,

        /// <summary>
        /// PluginGo
        /// </summary>
        PluginGo,

        /// <summary>
        /// PluginKey
        /// </summary>
        PluginKey,

        /// <summary>
        /// PluginLink
        /// </summary>
        PluginLink,

        /// <summary>
        /// PreviousGreen
        /// </summary>
        PreviousGreen,

        /// <summary>
        /// Printer
        /// </summary>
        Printer,

        /// <summary>
        /// PrinterAdd
        /// </summary>
        PrinterAdd,

        /// <summary>
        /// PrinterCancel
        /// </summary>
        PrinterCancel,

        /// <summary>
        /// PrinterColor
        /// </summary>
        PrinterColor,

        /// <summary>
        /// PrinterConnect
        /// </summary>
        PrinterConnect,

        /// <summary>
        /// PrinterDelete
        /// </summary>
        PrinterDelete,

        /// <summary>
        /// PrinterEmpty
        /// </summary>
        PrinterEmpty,

        /// <summary>
        /// PrinterError
        /// </summary>
        PrinterError,

        /// <summary>
        /// PrinterGo
        /// </summary>
        PrinterGo,

        /// <summary>
        /// PrinterKey
        /// </summary>
        PrinterKey,

        /// <summary>
        /// PrinterMono
        /// </summary>
        PrinterMono,

        /// <summary>
        /// PrinterStart
        /// </summary>
        PrinterStart,

        /// <summary>
        /// PrinterStop
        /// </summary>
        PrinterStop,

        /// <summary>
        /// Rainbow
        /// </summary>
        Rainbow,

        /// <summary>
        /// RainbowStar
        /// </summary>
        RainbowStar,

        /// <summary>
        /// RecordBlue
        /// </summary>
        RecordBlue,

        /// <summary>
        /// RecordGreen
        /// </summary>
        RecordGreen,

        /// <summary>
        /// RecordRed
        /// </summary>
        RecordRed,

        /// <summary>
        /// Reload
        /// </summary>
        Reload,

        /// <summary>
        /// Report
        /// </summary>
        Report,

        /// <summary>
        /// ReportAdd
        /// </summary>
        ReportAdd,

        /// <summary>
        /// ReportDelete
        /// </summary>
        ReportDelete,

        /// <summary>
        /// ReportDisk
        /// </summary>
        ReportDisk,

        /// <summary>
        /// ReportEdit
        /// </summary>
        ReportEdit,

        /// <summary>
        /// ReportGo
        /// </summary>
        ReportGo,

        /// <summary>
        /// ReportKey
        /// </summary>
        ReportKey,

        /// <summary>
        /// ReportLink
        /// </summary>
        ReportLink,

        /// <summary>
        /// ReportMagnify
        /// </summary>
        ReportMagnify,

        /// <summary>
        /// ReportPicture
        /// </summary>
        ReportPicture,

        /// <summary>
        /// ReportStart
        /// </summary>
        ReportStart,

        /// <summary>
        /// ReportStop
        /// </summary>
        ReportStop,

        /// <summary>
        /// ReportUser
        /// </summary>
        ReportUser,

        /// <summary>
        /// ReportWord
        /// </summary>
        ReportWord,

        /// <summary>
        /// ResultsetFirst
        /// </summary>
        ResultsetFirst,

        /// <summary>
        /// ResultsetLast
        /// </summary>
        ResultsetLast,

        /// <summary>
        /// ResultsetNext
        /// </summary>
        ResultsetNext,

        /// <summary>
        /// ResultsetPrevious
        /// </summary>
        ResultsetPrevious,

        /// <summary>
        /// ReverseBlue
        /// </summary>
        ReverseBlue,

        /// <summary>
        /// ReverseGreen
        /// </summary>
        ReverseGreen,

        /// <summary>
        /// RewindBlue
        /// </summary>
        RewindBlue,

        /// <summary>
        /// RewindGreen
        /// </summary>
        RewindGreen,

        /// <summary>
        /// Rgb
        /// </summary>
        Rgb,

        /// <summary>
        /// Rosette
        /// </summary>
        Rosette,

        /// <summary>
        /// RosetteBlue
        /// </summary>
        RosetteBlue,

        /// <summary>
        /// Rss
        /// </summary>
        Rss,

        /// <summary>
        /// RssAdd
        /// </summary>
        RssAdd,

        /// <summary>
        /// RssDelete
        /// </summary>
        RssDelete,

        /// <summary>
        /// RssError
        /// </summary>
        RssError,

        /// <summary>
        /// RssGo
        /// </summary>
        RssGo,

        /// <summary>
        /// RssValid
        /// </summary>
        RssValid,

        /// <summary>
        /// Ruby
        /// </summary>
        Ruby,

        /// <summary>
        /// RubyAdd
        /// </summary>
        RubyAdd,

        /// <summary>
        /// RubyDelete
        /// </summary>
        RubyDelete,

        /// <summary>
        /// RubyGear
        /// </summary>
        RubyGear,

        /// <summary>
        /// RubyGet
        /// </summary>
        RubyGet,

        /// <summary>
        /// RubyGo
        /// </summary>
        RubyGo,

        /// <summary>
        /// RubyKey
        /// </summary>
        RubyKey,

        /// <summary>
        /// RubyLink
        /// </summary>
        RubyLink,

        /// <summary>
        /// RubyPut
        /// </summary>
        RubyPut,

        /// <summary>
        /// Script
        /// </summary>
        Script,

        /// <summary>
        /// ScriptAdd
        /// </summary>
        ScriptAdd,

        /// <summary>
        /// ScriptCode
        /// </summary>
        ScriptCode,

        /// <summary>
        /// ScriptCodeOriginal
        /// </summary>
        ScriptCodeOriginal,

        /// <summary>
        /// ScriptCodeRed
        /// </summary>
        ScriptCodeRed,

        /// <summary>
        /// ScriptDelete
        /// </summary>
        ScriptDelete,

        /// <summary>
        /// ScriptEdit
        /// </summary>
        ScriptEdit,

        /// <summary>
        /// ScriptError
        /// </summary>
        ScriptError,

        /// <summary>
        /// ScriptGear
        /// </summary>
        ScriptGear,

        /// <summary>
        /// ScriptGo
        /// </summary>
        ScriptGo,

        /// <summary>
        /// ScriptKey
        /// </summary>
        ScriptKey,

        /// <summary>
        /// ScriptLightning
        /// </summary>
        ScriptLightning,

        /// <summary>
        /// ScriptLink
        /// </summary>
        ScriptLink,

        /// <summary>
        /// ScriptPalette
        /// </summary>
        ScriptPalette,

        /// <summary>
        /// ScriptSave
        /// </summary>
        ScriptSave,

        /// <summary>
        /// ScriptStart
        /// </summary>
        ScriptStart,

        /// <summary>
        /// ScriptStop
        /// </summary>
        ScriptStop,

        /// <summary>
        /// Seasons
        /// </summary>
        Seasons,

        /// <summary>
        /// SectionCollapsed
        /// </summary>
        SectionCollapsed,

        /// <summary>
        /// SectionExpanded
        /// </summary>
        SectionExpanded,

        /// <summary>
        /// Server
        /// </summary>
        Server,

        /// <summary>
        /// ServerAdd
        /// </summary>
        ServerAdd,

        /// <summary>
        /// ServerChart
        /// </summary>
        ServerChart,

        /// <summary>
        /// ServerCompressed
        /// </summary>
        ServerCompressed,

        /// <summary>
        /// ServerConnect
        /// </summary>
        ServerConnect,

        /// <summary>
        /// ServerDatabase
        /// </summary>
        ServerDatabase,

        /// <summary>
        /// ServerDelete
        /// </summary>
        ServerDelete,

        /// <summary>
        /// ServerEdit
        /// </summary>
        ServerEdit,

        /// <summary>
        /// ServerError
        /// </summary>
        ServerError,

        /// <summary>
        /// ServerGo
        /// </summary>
        ServerGo,

        /// <summary>
        /// ServerKey
        /// </summary>
        ServerKey,

        /// <summary>
        /// ServerLightning
        /// </summary>
        ServerLightning,

        /// <summary>
        /// ServerLink
        /// </summary>
        ServerLink,

        /// <summary>
        /// ServerStart
        /// </summary>
        ServerStart,

        /// <summary>
        /// ServerStop
        /// </summary>
        ServerStop,

        /// <summary>
        /// ServerUncompressed
        /// </summary>
        ServerUncompressed,

        /// <summary>
        /// ServerWrench
        /// </summary>
        ServerWrench,

        /// <summary>
        /// Shading
        /// </summary>
        Shading,

        /// <summary>
        /// ShapesMany
        /// </summary>
        ShapesMany,

        /// <summary>
        /// ShapesManySelect
        /// </summary>
        ShapesManySelect,

        /// <summary>
        /// Shape3d
        /// </summary>
        Shape3d,

        /// <summary>
        /// ShapeAlignBottom
        /// </summary>
        ShapeAlignBottom,

        /// <summary>
        /// ShapeAlignCenter
        /// </summary>
        ShapeAlignCenter,

        /// <summary>
        /// ShapeAlignLeft
        /// </summary>
        ShapeAlignLeft,

        /// <summary>
        /// ShapeAlignMiddle
        /// </summary>
        ShapeAlignMiddle,

        /// <summary>
        /// ShapeAlignRight
        /// </summary>
        ShapeAlignRight,

        /// <summary>
        /// ShapeAlignTop
        /// </summary>
        ShapeAlignTop,

        /// <summary>
        /// ShapeFlipHorizontal
        /// </summary>
        ShapeFlipHorizontal,

        /// <summary>
        /// ShapeFlipVertical
        /// </summary>
        ShapeFlipVertical,

        /// <summary>
        /// ShapeGroup
        /// </summary>
        ShapeGroup,

        /// <summary>
        /// ShapeHandles
        /// </summary>
        ShapeHandles,

        /// <summary>
        /// ShapeMoveBack
        /// </summary>
        ShapeMoveBack,

        /// <summary>
        /// ShapeMoveBackwards
        /// </summary>
        ShapeMoveBackwards,

        /// <summary>
        /// ShapeMoveForwards
        /// </summary>
        ShapeMoveForwards,

        /// <summary>
        /// ShapeMoveFront
        /// </summary>
        ShapeMoveFront,

        /// <summary>
        /// ShapeRotateAnticlockwise
        /// </summary>
        ShapeRotateAnticlockwise,

        /// <summary>
        /// ShapeRotateClockwise
        /// </summary>
        ShapeRotateClockwise,

        /// <summary>
        /// ShapeShadeA
        /// </summary>
        ShapeShadeA,

        /// <summary>
        /// ShapeShadeB
        /// </summary>
        ShapeShadeB,

        /// <summary>
        /// ShapeShadeC
        /// </summary>
        ShapeShadeC,

        /// <summary>
        /// ShapeShadow
        /// </summary>
        ShapeShadow,

        /// <summary>
        /// ShapeShadowToggle
        /// </summary>
        ShapeShadowToggle,

        /// <summary>
        /// ShapeSquare
        /// </summary>
        ShapeSquare,

        /// <summary>
        /// ShapeSquareAdd
        /// </summary>
        ShapeSquareAdd,

        /// <summary>
        /// ShapeSquareDelete
        /// </summary>
        ShapeSquareDelete,

        /// <summary>
        /// ShapeSquareEdit
        /// </summary>
        ShapeSquareEdit,

        /// <summary>
        /// ShapeSquareError
        /// </summary>
        ShapeSquareError,

        /// <summary>
        /// ShapeSquareGo
        /// </summary>
        ShapeSquareGo,

        /// <summary>
        /// ShapeSquareKey
        /// </summary>
        ShapeSquareKey,

        /// <summary>
        /// ShapeSquareLink
        /// </summary>
        ShapeSquareLink,

        /// <summary>
        /// ShapeSquareSelect
        /// </summary>
        ShapeSquareSelect,

        /// <summary>
        /// ShapeUngroup
        /// </summary>
        ShapeUngroup,

        /// <summary>
        /// Share
        /// </summary>
        Share,

        /// <summary>
        /// Shield
        /// </summary>
        Shield,

        /// <summary>
        /// ShieldAdd
        /// </summary>
        ShieldAdd,

        /// <summary>
        /// ShieldDelete
        /// </summary>
        ShieldDelete,

        /// <summary>
        /// ShieldError
        /// </summary>
        ShieldError,

        /// <summary>
        /// ShieldGo
        /// </summary>
        ShieldGo,

        /// <summary>
        /// ShieldRainbow
        /// </summary>
        ShieldRainbow,

        /// <summary>
        /// ShieldSilver
        /// </summary>
        ShieldSilver,

        /// <summary>
        /// ShieldStart
        /// </summary>
        ShieldStart,

        /// <summary>
        /// ShieldStop
        /// </summary>
        ShieldStop,

        /// <summary>
        /// Sitemap
        /// </summary>
        Sitemap,

        /// <summary>
        /// SitemapColor
        /// </summary>
        SitemapColor,

        /// <summary>
        /// Smartphone
        /// </summary>
        Smartphone,

        /// <summary>
        /// SmartphoneAdd
        /// </summary>
        SmartphoneAdd,

        /// <summary>
        /// SmartphoneConnect
        /// </summary>
        SmartphoneConnect,

        /// <summary>
        /// SmartphoneDelete
        /// </summary>
        SmartphoneDelete,

        /// <summary>
        /// SmartphoneDisk
        /// </summary>
        SmartphoneDisk,

        /// <summary>
        /// SmartphoneEdit
        /// </summary>
        SmartphoneEdit,

        /// <summary>
        /// SmartphoneError
        /// </summary>
        SmartphoneError,

        /// <summary>
        /// SmartphoneGo
        /// </summary>
        SmartphoneGo,

        /// <summary>
        /// SmartphoneKey
        /// </summary>
        SmartphoneKey,

        /// <summary>
        /// SmartphoneWrench
        /// </summary>
        SmartphoneWrench,

        /// <summary>
        /// SortAscending
        /// </summary>
        SortAscending,

        /// <summary>
        /// SortDescending
        /// </summary>
        SortDescending,

        /// <summary>
        /// Sound
        /// </summary>
        Sound,

        /// <summary>
        /// SoundAdd
        /// </summary>
        SoundAdd,

        /// <summary>
        /// SoundDelete
        /// </summary>
        SoundDelete,

        /// <summary>
        /// SoundHigh
        /// </summary>
        SoundHigh,

        /// <summary>
        /// SoundIn
        /// </summary>
        SoundIn,

        /// <summary>
        /// SoundLow
        /// </summary>
        SoundLow,

        /// <summary>
        /// SoundMute
        /// </summary>
        SoundMute,

        /// <summary>
        /// SoundNone
        /// </summary>
        SoundNone,

        /// <summary>
        /// SoundOut
        /// </summary>
        SoundOut,

        /// <summary>
        /// Spellcheck
        /// </summary>
        Spellcheck,

        /// <summary>
        /// Sport8ball
        /// </summary>
        Sport8ball,

        /// <summary>
        /// SportBasketball
        /// </summary>
        SportBasketball,

        /// <summary>
        /// SportFootball
        /// </summary>
        SportFootball,

        /// <summary>
        /// SportGolf
        /// </summary>
        SportGolf,

        /// <summary>
        /// SportGolfPractice
        /// </summary>
        SportGolfPractice,

        /// <summary>
        /// SportRaquet
        /// </summary>
        SportRaquet,

        /// <summary>
        /// SportShuttlecock
        /// </summary>
        SportShuttlecock,

        /// <summary>
        /// SportSoccer
        /// </summary>
        SportSoccer,

        /// <summary>
        /// SportTennis
        /// </summary>
        SportTennis,

        /// <summary>
        /// Star
        /// </summary>
        Star,

        /// <summary>
        /// StarBronze
        /// </summary>
        StarBronze,

        /// <summary>
        /// StarBronzeHalfGrey
        /// </summary>
        StarBronzeHalfGrey,

        /// <summary>
        /// StarGold
        /// </summary>
        StarGold,

        /// <summary>
        /// StarGoldHalfGrey
        /// </summary>
        StarGoldHalfGrey,

        /// <summary>
        /// StarGoldHalfSilver
        /// </summary>
        StarGoldHalfSilver,

        /// <summary>
        /// StarGrey
        /// </summary>
        StarGrey,

        /// <summary>
        /// StarHalfGrey
        /// </summary>
        StarHalfGrey,

        /// <summary>
        /// StarSilver
        /// </summary>
        StarSilver,

        /// <summary>
        /// StatusAway
        /// </summary>
        StatusAway,

        /// <summary>
        /// StatusBeRightBack
        /// </summary>
        StatusBeRightBack,

        /// <summary>
        /// StatusBusy
        /// </summary>
        StatusBusy,

        /// <summary>
        /// StatusInvisible
        /// </summary>
        StatusInvisible,

        /// <summary>
        /// StatusOffline
        /// </summary>
        StatusOffline,

        /// <summary>
        /// StatusOnline
        /// </summary>
        StatusOnline,

        /// <summary>
        /// Stop
        /// </summary>
        Stop,

        /// <summary>
        /// StopBlue
        /// </summary>
        StopBlue,

        /// <summary>
        /// StopGreen
        /// </summary>
        StopGreen,

        /// <summary>
        /// StopRed
        /// </summary>
        StopRed,

        /// <summary>
        /// Style
        /// </summary>
        Style,

        /// <summary>
        /// StyleAdd
        /// </summary>
        StyleAdd,

        /// <summary>
        /// StyleDelete
        /// </summary>
        StyleDelete,

        /// <summary>
        /// StyleEdit
        /// </summary>
        StyleEdit,

        /// <summary>
        /// StyleGo
        /// </summary>
        StyleGo,

        /// <summary>
        /// Sum
        /// </summary>
        Sum,

        /// <summary>
        /// Tab
        /// </summary>
        Tab,

        /// <summary>
        /// Table
        /// </summary>
        Table,

        /// <summary>
        /// TableAdd
        /// </summary>
        TableAdd,

        /// <summary>
        /// TableCell
        /// </summary>
        TableCell,

        /// <summary>
        /// TableColumn
        /// </summary>
        TableColumn,

        /// <summary>
        /// TableColumnAdd
        /// </summary>
        TableColumnAdd,

        /// <summary>
        /// TableColumnDelete
        /// </summary>
        TableColumnDelete,

        /// <summary>
        /// TableConnect
        /// </summary>
        TableConnect,

        /// <summary>
        /// TableDelete
        /// </summary>
        TableDelete,

        /// <summary>
        /// TableEdit
        /// </summary>
        TableEdit,

        /// <summary>
        /// TableError
        /// </summary>
        TableError,

        /// <summary>
        /// TableGear
        /// </summary>
        TableGear,

        /// <summary>
        /// TableGo
        /// </summary>
        TableGo,

        /// <summary>
        /// TableKey
        /// </summary>
        TableKey,

        /// <summary>
        /// TableLightning
        /// </summary>
        TableLightning,

        /// <summary>
        /// TableLink
        /// </summary>
        TableLink,

        /// <summary>
        /// TableMultiple
        /// </summary>
        TableMultiple,

        /// <summary>
        /// TableRefresh
        /// </summary>
        TableRefresh,

        /// <summary>
        /// TableRelationship
        /// </summary>
        TableRelationship,

        /// <summary>
        /// TableRow
        /// </summary>
        TableRow,

        /// <summary>
        /// TableRowDelete
        /// </summary>
        TableRowDelete,

        /// <summary>
        /// TableRowInsert
        /// </summary>
        TableRowInsert,

        /// <summary>
        /// TableSave
        /// </summary>
        TableSave,

        /// <summary>
        /// TableSort
        /// </summary>
        TableSort,

        /// <summary>
        /// TabAdd
        /// </summary>
        TabAdd,

        /// <summary>
        /// TabBlue
        /// </summary>
        TabBlue,

        /// <summary>
        /// TabDelete
        /// </summary>
        TabDelete,

        /// <summary>
        /// TabEdit
        /// </summary>
        TabEdit,

        /// <summary>
        /// TabGo
        /// </summary>
        TabGo,

        /// <summary>
        /// TabGreen
        /// </summary>
        TabGreen,

        /// <summary>
        /// TabRed
        /// </summary>
        TabRed,

        /// <summary>
        /// Tag
        /// </summary>
        Tag,

        /// <summary>
        /// TagsGrey
        /// </summary>
        TagsGrey,

        /// <summary>
        /// TagsRed
        /// </summary>
        TagsRed,

        /// <summary>
        /// TagBlue
        /// </summary>
        TagBlue,

        /// <summary>
        /// TagBlueAdd
        /// </summary>
        TagBlueAdd,

        /// <summary>
        /// TagBlueDelete
        /// </summary>
        TagBlueDelete,

        /// <summary>
        /// TagBlueEdit
        /// </summary>
        TagBlueEdit,

        /// <summary>
        /// TagGreen
        /// </summary>
        TagGreen,

        /// <summary>
        /// TagOrange
        /// </summary>
        TagOrange,

        /// <summary>
        /// TagPink
        /// </summary>
        TagPink,

        /// <summary>
        /// TagPurple
        /// </summary>
        TagPurple,

        /// <summary>
        /// TagRed
        /// </summary>
        TagRed,

        /// <summary>
        /// TagYellow
        /// </summary>
        TagYellow,

        /// <summary>
        /// Telephone
        /// </summary>
        Telephone,

        /// <summary>
        /// TelephoneAdd
        /// </summary>
        TelephoneAdd,

        /// <summary>
        /// TelephoneDelete
        /// </summary>
        TelephoneDelete,

        /// <summary>
        /// TelephoneEdit
        /// </summary>
        TelephoneEdit,

        /// <summary>
        /// TelephoneError
        /// </summary>
        TelephoneError,

        /// <summary>
        /// TelephoneGo
        /// </summary>
        TelephoneGo,

        /// <summary>
        /// TelephoneKey
        /// </summary>
        TelephoneKey,

        /// <summary>
        /// TelephoneLink
        /// </summary>
        TelephoneLink,

        /// <summary>
        /// TelephoneRed
        /// </summary>
        TelephoneRed,

        /// <summary>
        /// Television
        /// </summary>
        Television,

        /// <summary>
        /// TelevisionAdd
        /// </summary>
        TelevisionAdd,

        /// <summary>
        /// TelevisionDelete
        /// </summary>
        TelevisionDelete,

        /// <summary>
        /// TelevisionIn
        /// </summary>
        TelevisionIn,

        /// <summary>
        /// TelevisionOff
        /// </summary>
        TelevisionOff,

        /// <summary>
        /// TelevisionOut
        /// </summary>
        TelevisionOut,

        /// <summary>
        /// TelevisionStar
        /// </summary>
        TelevisionStar,

        /// <summary>
        /// Textfield
        /// </summary>
        Textfield,

        /// <summary>
        /// TextfieldAdd
        /// </summary>
        TextfieldAdd,

        /// <summary>
        /// TextfieldDelete
        /// </summary>
        TextfieldDelete,

        /// <summary>
        /// TextfieldKey
        /// </summary>
        TextfieldKey,

        /// <summary>
        /// TextfieldRename
        /// </summary>
        TextfieldRename,

        /// <summary>
        /// TextAb
        /// </summary>
        TextAb,

        /// <summary>
        /// TextAlignCenter
        /// </summary>
        TextAlignCenter,

        /// <summary>
        /// TextAlignJustify
        /// </summary>
        TextAlignJustify,

        /// <summary>
        /// TextAlignLeft
        /// </summary>
        TextAlignLeft,

        /// <summary>
        /// TextAlignRight
        /// </summary>
        TextAlignRight,

        /// <summary>
        /// TextAllcaps
        /// </summary>
        TextAllcaps,

        /// <summary>
        /// TextBold
        /// </summary>
        TextBold,

        /// <summary>
        /// TextColumns
        /// </summary>
        TextColumns,

        /// <summary>
        /// TextComplete
        /// </summary>
        TextComplete,

        /// <summary>
        /// TextDirection
        /// </summary>
        TextDirection,

        /// <summary>
        /// TextDoubleUnderline
        /// </summary>
        TextDoubleUnderline,

        /// <summary>
        /// TextDropcaps
        /// </summary>
        TextDropcaps,

        /// <summary>
        /// TextFit
        /// </summary>
        TextFit,

        /// <summary>
        /// TextFlip
        /// </summary>
        TextFlip,

        /// <summary>
        /// TextFontDefault
        /// </summary>
        TextFontDefault,

        /// <summary>
        /// TextHeading1
        /// </summary>
        TextHeading1,

        /// <summary>
        /// TextHeading2
        /// </summary>
        TextHeading2,

        /// <summary>
        /// TextHeading3
        /// </summary>
        TextHeading3,

        /// <summary>
        /// TextHeading4
        /// </summary>
        TextHeading4,

        /// <summary>
        /// TextHeading5
        /// </summary>
        TextHeading5,

        /// <summary>
        /// TextHeading6
        /// </summary>
        TextHeading6,

        /// <summary>
        /// TextHorizontalrule
        /// </summary>
        TextHorizontalrule,

        /// <summary>
        /// TextIndent
        /// </summary>
        TextIndent,

        /// <summary>
        /// TextIndentRemove
        /// </summary>
        TextIndentRemove,

        /// <summary>
        /// TextInverse
        /// </summary>
        TextInverse,

        /// <summary>
        /// TextItalic
        /// </summary>
        TextItalic,

        /// <summary>
        /// TextKerning
        /// </summary>
        TextKerning,

        /// <summary>
        /// TextLeftToRight
        /// </summary>
        TextLeftToRight,

        /// <summary>
        /// TextLetterspacing
        /// </summary>
        TextLetterspacing,

        /// <summary>
        /// TextLetterOmega
        /// </summary>
        TextLetterOmega,

        /// <summary>
        /// TextLinespacing
        /// </summary>
        TextLinespacing,

        /// <summary>
        /// TextListBullets
        /// </summary>
        TextListBullets,

        /// <summary>
        /// TextListNumbers
        /// </summary>
        TextListNumbers,

        /// <summary>
        /// TextLowercase
        /// </summary>
        TextLowercase,

        /// <summary>
        /// TextLowercaseA
        /// </summary>
        TextLowercaseA,

        /// <summary>
        /// TextMirror
        /// </summary>
        TextMirror,

        /// <summary>
        /// TextPaddingBottom
        /// </summary>
        TextPaddingBottom,

        /// <summary>
        /// TextPaddingLeft
        /// </summary>
        TextPaddingLeft,

        /// <summary>
        /// TextPaddingRight
        /// </summary>
        TextPaddingRight,

        /// <summary>
        /// TextPaddingTop
        /// </summary>
        TextPaddingTop,

        /// <summary>
        /// TextReplace
        /// </summary>
        TextReplace,

        /// <summary>
        /// TextRightToLeft
        /// </summary>
        TextRightToLeft,

        /// <summary>
        /// TextRotate0
        /// </summary>
        TextRotate0,

        /// <summary>
        /// TextRotate180
        /// </summary>
        TextRotate180,

        /// <summary>
        /// TextRotate270
        /// </summary>
        TextRotate270,

        /// <summary>
        /// TextRotate90
        /// </summary>
        TextRotate90,

        /// <summary>
        /// TextRuler
        /// </summary>
        TextRuler,

        /// <summary>
        /// TextShading
        /// </summary>
        TextShading,

        /// <summary>
        /// TextSignature
        /// </summary>
        TextSignature,

        /// <summary>
        /// TextSmallcaps
        /// </summary>
        TextSmallcaps,

        /// <summary>
        /// TextSpelling
        /// </summary>
        TextSpelling,

        /// <summary>
        /// TextStrikethrough
        /// </summary>
        TextStrikethrough,

        /// <summary>
        /// TextSubscript
        /// </summary>
        TextSubscript,

        /// <summary>
        /// TextSuperscript
        /// </summary>
        TextSuperscript,

        /// <summary>
        /// TextTab
        /// </summary>
        TextTab,

        /// <summary>
        /// TextUnderline
        /// </summary>
        TextUnderline,

        /// <summary>
        /// TextUppercase
        /// </summary>
        TextUppercase,

        /// <summary>
        /// Theme
        /// </summary>
        Theme,

        /// <summary>
        /// ThumbDown
        /// </summary>
        ThumbDown,

        /// <summary>
        /// ThumbUp
        /// </summary>
        ThumbUp,

        /// <summary>
        /// Tick
        /// </summary>
        Tick,

        /// <summary>
        /// Time
        /// </summary>
        Time,

        /// <summary>
        /// TimelineMarker
        /// </summary>
        TimelineMarker,

        /// <summary>
        /// TimeAdd
        /// </summary>
        TimeAdd,

        /// <summary>
        /// TimeDelete
        /// </summary>
        TimeDelete,

        /// <summary>
        /// TimeGo
        /// </summary>
        TimeGo,

        /// <summary>
        /// TimeGreen
        /// </summary>
        TimeGreen,

        /// <summary>
        /// TimeRed
        /// </summary>
        TimeRed,

        /// <summary>
        /// Transmit
        /// </summary>
        Transmit,

        /// <summary>
        /// TransmitAdd
        /// </summary>
        TransmitAdd,

        /// <summary>
        /// TransmitBlue
        /// </summary>
        TransmitBlue,

        /// <summary>
        /// TransmitDelete
        /// </summary>
        TransmitDelete,

        /// <summary>
        /// TransmitEdit
        /// </summary>
        TransmitEdit,

        /// <summary>
        /// TransmitError
        /// </summary>
        TransmitError,

        /// <summary>
        /// TransmitGo
        /// </summary>
        TransmitGo,

        /// <summary>
        /// TransmitRed
        /// </summary>
        TransmitRed,

        /// <summary>
        /// Tux
        /// </summary>
        Tux,

        /// <summary>
        /// User
        /// </summary>
        User,

        /// <summary>
        /// UserAdd
        /// </summary>
        UserAdd,

        /// <summary>
        /// UserAlert
        /// </summary>
        UserAlert,

        /// <summary>
        /// UserB
        /// </summary>
        UserB,

        /// <summary>
        /// UserBrown
        /// </summary>
        UserBrown,

        /// <summary>
        /// UserComment
        /// </summary>
        UserComment,

        /// <summary>
        /// UserCross
        /// </summary>
        UserCross,

        /// <summary>
        /// UserDelete
        /// </summary>
        UserDelete,

        /// <summary>
        /// UserEarth
        /// </summary>
        UserEarth,

        /// <summary>
        /// UserEdit
        /// </summary>
        UserEdit,

        /// <summary>
        /// UserFemale
        /// </summary>
        UserFemale,

        /// <summary>
        /// UserGo
        /// </summary>
        UserGo,

        /// <summary>
        /// UserGray
        /// </summary>
        UserGray,

        /// <summary>
        /// UserGrayCool
        /// </summary>
        UserGrayCool,

        /// <summary>
        /// UserGreen
        /// </summary>
        UserGreen,

        /// <summary>
        /// UserHome
        /// </summary>
        UserHome,

        /// <summary>
        /// UserKey
        /// </summary>
        UserKey,

        /// <summary>
        /// UserMagnify
        /// </summary>
        UserMagnify,

        /// <summary>
        /// UserMature
        /// </summary>
        UserMature,

        /// <summary>
        /// UserOrange
        /// </summary>
        UserOrange,

        /// <summary>
        /// UserRed
        /// </summary>
        UserRed,

        /// <summary>
        /// UserStar
        /// </summary>
        UserStar,

        /// <summary>
        /// UserSuit
        /// </summary>
        UserSuit,

        /// <summary>
        /// UserSuitBlack
        /// </summary>
        UserSuitBlack,

        /// <summary>
        /// UserTick
        /// </summary>
        UserTick,

        /// <summary>
        /// Vcard
        /// </summary>
        Vcard,

        /// <summary>
        /// VcardAdd
        /// </summary>
        VcardAdd,

        /// <summary>
        /// VcardDelete
        /// </summary>
        VcardDelete,

        /// <summary>
        /// VcardEdit
        /// </summary>
        VcardEdit,

        /// <summary>
        /// VcardKey
        /// </summary>
        VcardKey,

        /// <summary>
        /// Vector
        /// </summary>
        Vector,

        /// <summary>
        /// VectorAdd
        /// </summary>
        VectorAdd,

        /// <summary>
        /// VectorDelete
        /// </summary>
        VectorDelete,

        /// <summary>
        /// VectorKey
        /// </summary>
        VectorKey,

        /// <summary>
        /// Wand
        /// </summary>
        Wand,

        /// <summary>
        /// WeatherCloud
        /// </summary>
        WeatherCloud,

        /// <summary>
        /// WeatherClouds
        /// </summary>
        WeatherClouds,

        /// <summary>
        /// WeatherCloudy
        /// </summary>
        WeatherCloudy,

        /// <summary>
        /// WeatherCloudyRain
        /// </summary>
        WeatherCloudyRain,

        /// <summary>
        /// WeatherLightning
        /// </summary>
        WeatherLightning,

        /// <summary>
        /// WeatherRain
        /// </summary>
        WeatherRain,

        /// <summary>
        /// WeatherSnow
        /// </summary>
        WeatherSnow,

        /// <summary>
        /// WeatherSun
        /// </summary>
        WeatherSun,

        /// <summary>
        /// Webcam
        /// </summary>
        Webcam,

        /// <summary>
        /// WebcamAdd
        /// </summary>
        WebcamAdd,

        /// <summary>
        /// WebcamConnect
        /// </summary>
        WebcamConnect,

        /// <summary>
        /// WebcamDelete
        /// </summary>
        WebcamDelete,

        /// <summary>
        /// WebcamError
        /// </summary>
        WebcamError,

        /// <summary>
        /// WebcamStart
        /// </summary>
        WebcamStart,

        /// <summary>
        /// WebcamStop
        /// </summary>
        WebcamStop,

        /// <summary>
        /// World
        /// </summary>
        World,

        /// <summary>
        /// WorldAdd
        /// </summary>
        WorldAdd,

        /// <summary>
        /// WorldConnect
        /// </summary>
        WorldConnect,

        /// <summary>
        /// WorldDawn
        /// </summary>
        WorldDawn,

        /// <summary>
        /// WorldDelete
        /// </summary>
        WorldDelete,

        /// <summary>
        /// WorldEdit
        /// </summary>
        WorldEdit,

        /// <summary>
        /// WorldGo
        /// </summary>
        WorldGo,

        /// <summary>
        /// WorldKey
        /// </summary>
        WorldKey,

        /// <summary>
        /// WorldLink
        /// </summary>
        WorldLink,

        /// <summary>
        /// WorldNight
        /// </summary>
        WorldNight,

        /// <summary>
        /// WorldOrbit
        /// </summary>
        WorldOrbit,

        /// <summary>
        /// Wrench
        /// </summary>
        Wrench,

        /// <summary>
        /// WrenchOrange
        /// </summary>
        WrenchOrange,

        /// <summary>
        /// Xhtml
        /// </summary>
        Xhtml,

        /// <summary>
        /// XhtmlAdd
        /// </summary>
        XhtmlAdd,

        /// <summary>
        /// XhtmlDelete
        /// </summary>
        XhtmlDelete,

        /// <summary>
        /// XhtmlError
        /// </summary>
        XhtmlError,

        /// <summary>
        /// XhtmlGo
        /// </summary>
        XhtmlGo,

        /// <summary>
        /// XhtmlValid
        /// </summary>
        XhtmlValid,

        /// <summary>
        /// Zoom
        /// </summary>
        Zoom,

        /// <summary>
        /// ZoomIn
        /// </summary>
        ZoomIn,

        /// <summary>
        /// ZoomOut
        /// </summary>
        ZoomOut,

        /// <summary>
        /// SystemClose
        /// </summary>
        SystemClose,

        /// <summary>
        /// SystemNew
        /// </summary>
        SystemNew,

        /// <summary>
        /// SystemSave
        /// </summary>
        SystemSave,

        /// <summary>
        /// SystemSaveClose
        /// </summary>
        SystemSaveClose,

        /// <summary>
        /// SystemSaveNew
        /// </summary>
        SystemSaveNew,

        /// <summary>
        /// SystemSearch
        /// </summary>
        SystemSearch
    }

    /// <summary>
    /// 预定义图标名称
    /// </summary>
    public static partial class IconHelper
    {
        /// <summary>
        /// 获取图标名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetName(Icon type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Icon.None:
                    result = "";
                    break;
                case Icon.Accept:
                    result = "accept.png";
                    break;
                case Icon.Add:
                    result = "add.png";
                    break;
                case Icon.Anchor:
                    result = "anchor.png";
                    break;
                case Icon.Application:
                    result = "application.png";
                    break;
                case Icon.ApplicationAdd:
                    result = "application_add.png";
                    break;
                case Icon.ApplicationCascade:
                    result = "application_cascade.png";
                    break;
                case Icon.ApplicationDelete:
                    result = "application_delete.png";
                    break;
                case Icon.ApplicationDouble:
                    result = "application_double.png";
                    break;
                case Icon.ApplicationEdit:
                    result = "application_edit.png";
                    break;
                case Icon.ApplicationError:
                    result = "application_error.png";
                    break;
                case Icon.ApplicationForm:
                    result = "application_form.png";
                    break;
                case Icon.ApplicationFormAdd:
                    result = "application_form_add.png";
                    break;
                case Icon.ApplicationFormDelete:
                    result = "application_form_delete.png";
                    break;
                case Icon.ApplicationFormEdit:
                    result = "application_form_edit.png";
                    break;
                case Icon.ApplicationFormMagnify:
                    result = "application_form_magnify.png";
                    break;
                case Icon.ApplicationGet:
                    result = "application_get.png";
                    break;
                case Icon.ApplicationGo:
                    result = "application_go.png";
                    break;
                case Icon.ApplicationHome:
                    result = "application_home.png";
                    break;
                case Icon.ApplicationKey:
                    result = "application_key.png";
                    break;
                case Icon.ApplicationLightning:
                    result = "application_lightning.png";
                    break;
                case Icon.ApplicationLink:
                    result = "application_link.png";
                    break;
                case Icon.ApplicationOsx:
                    result = "application_osx.png";
                    break;
                case Icon.ApplicationOsxAdd:
                    result = "application_osx_add.png";
                    break;
                case Icon.ApplicationOsxCascade:
                    result = "application_osx_cascade.png";
                    break;
                case Icon.ApplicationOsxDelete:
                    result = "application_osx_delete.png";
                    break;
                case Icon.ApplicationOsxDouble:
                    result = "application_osx_double.png";
                    break;
                case Icon.ApplicationOsxError:
                    result = "application_osx_error.png";
                    break;
                case Icon.ApplicationOsxGet:
                    result = "application_osx_get.png";
                    break;
                case Icon.ApplicationOsxGo:
                    result = "application_osx_go.png";
                    break;
                case Icon.ApplicationOsxHome:
                    result = "application_osx_home.png";
                    break;
                case Icon.ApplicationOsxKey:
                    result = "application_osx_key.png";
                    break;
                case Icon.ApplicationOsxLightning:
                    result = "application_osx_lightning.png";
                    break;
                case Icon.ApplicationOsxLink:
                    result = "application_osx_link.png";
                    break;
                case Icon.ApplicationOsxSplit:
                    result = "application_osx_split.png";
                    break;
                case Icon.ApplicationOsxStart:
                    result = "application_osx_start.png";
                    break;
                case Icon.ApplicationOsxStop:
                    result = "application_osx_stop.png";
                    break;
                case Icon.ApplicationOsxTerminal:
                    result = "application_osx_terminal.png";
                    break;
                case Icon.ApplicationPut:
                    result = "application_put.png";
                    break;
                case Icon.ApplicationSideBoxes:
                    result = "application_side_boxes.png";
                    break;
                case Icon.ApplicationSideContract:
                    result = "application_side_contract.png";
                    break;
                case Icon.ApplicationSideExpand:
                    result = "application_side_expand.png";
                    break;
                case Icon.ApplicationSideList:
                    result = "application_side_list.png";
                    break;
                case Icon.ApplicationSideTree:
                    result = "application_side_tree.png";
                    break;
                case Icon.ApplicationSplit:
                    result = "application_split.png";
                    break;
                case Icon.ApplicationStart:
                    result = "application_start.png";
                    break;
                case Icon.ApplicationStop:
                    result = "application_stop.png";
                    break;
                case Icon.ApplicationTileHorizontal:
                    result = "application_tile_horizontal.png";
                    break;
                case Icon.ApplicationTileVertical:
                    result = "application_tile_vertical.png";
                    break;
                case Icon.ApplicationViewColumns:
                    result = "application_view_columns.png";
                    break;
                case Icon.ApplicationViewDetail:
                    result = "application_view_detail.png";
                    break;
                case Icon.ApplicationViewGallery:
                    result = "application_view_gallery.png";
                    break;
                case Icon.ApplicationViewIcons:
                    result = "application_view_icons.png";
                    break;
                case Icon.ApplicationViewList:
                    result = "application_view_list.png";
                    break;
                case Icon.ApplicationViewTile:
                    result = "application_view_tile.png";
                    break;
                case Icon.ApplicationXp:
                    result = "application_xp.png";
                    break;
                case Icon.ApplicationXpTerminal:
                    result = "application_xp_terminal.png";
                    break;
                case Icon.ArrowBranch:
                    result = "arrow_branch.png";
                    break;
                case Icon.ArrowDivide:
                    result = "arrow_divide.png";
                    break;
                case Icon.ArrowDown:
                    result = "arrow_down.png";
                    break;
                case Icon.ArrowEw:
                    result = "arrow_ew.png";
                    break;
                case Icon.ArrowIn:
                    result = "arrow_in.png";
                    break;
                case Icon.ArrowInout:
                    result = "arrow_inout.png";
                    break;
                case Icon.ArrowInLonger:
                    result = "arrow_in_longer.png";
                    break;
                case Icon.ArrowJoin:
                    result = "arrow_join.png";
                    break;
                case Icon.ArrowLeft:
                    result = "arrow_left.png";
                    break;
                case Icon.ArrowMerge:
                    result = "arrow_merge.png";
                    break;
                case Icon.ArrowNe:
                    result = "arrow_ne.png";
                    break;
                case Icon.ArrowNs:
                    result = "arrow_ns.png";
                    break;
                case Icon.ArrowNsew:
                    result = "arrow_nsew.png";
                    break;
                case Icon.ArrowNw:
                    result = "arrow_nw.png";
                    break;
                case Icon.ArrowNwNeSwSe:
                    result = "arrow_nw_ne_sw_se.png";
                    break;
                case Icon.ArrowNwSe:
                    result = "arrow_nw_se.png";
                    break;
                case Icon.ArrowOut:
                    result = "arrow_out.png";
                    break;
                case Icon.ArrowOutLonger:
                    result = "arrow_out_longer.png";
                    break;
                case Icon.ArrowRedo:
                    result = "arrow_redo.png";
                    break;
                case Icon.ArrowRefresh:
                    result = "arrow_refresh.png";
                    break;
                case Icon.ArrowRefreshSmall:
                    result = "arrow_refresh_small.png";
                    break;
                case Icon.ArrowRight:
                    result = "arrow_right.png";
                    break;
                case Icon.ArrowRotateAnticlockwise:
                    result = "arrow_rotate_anticlockwise.png";
                    break;
                case Icon.ArrowRotateClockwise:
                    result = "arrow_rotate_clockwise.png";
                    break;
                case Icon.ArrowSe:
                    result = "arrow_se.png";
                    break;
                case Icon.ArrowSw:
                    result = "arrow_sw.png";
                    break;
                case Icon.ArrowSwitch:
                    result = "arrow_switch.png";
                    break;
                case Icon.ArrowSwitchBluegreen:
                    result = "arrow_switch_bluegreen.png";
                    break;
                case Icon.ArrowSwNe:
                    result = "arrow_sw_ne.png";
                    break;
                case Icon.ArrowTurnLeft:
                    result = "arrow_turn_left.png";
                    break;
                case Icon.ArrowTurnRight:
                    result = "arrow_turn_right.png";
                    break;
                case Icon.ArrowUndo:
                    result = "arrow_undo.png";
                    break;
                case Icon.ArrowUp:
                    result = "arrow_up.png";
                    break;
                case Icon.AsteriskOrange:
                    result = "asterisk_orange.png";
                    break;
                case Icon.AsteriskRed:
                    result = "asterisk_red.png";
                    break;
                case Icon.AsteriskYellow:
                    result = "asterisk_yellow.png";
                    break;
                case Icon.Attach:
                    result = "attach.png";
                    break;
                case Icon.AwardStarAdd:
                    result = "award_star_add.png";
                    break;
                case Icon.AwardStarBronze1:
                    result = "award_star_bronze_1.png";
                    break;
                case Icon.AwardStarBronze2:
                    result = "award_star_bronze_2.png";
                    break;
                case Icon.AwardStarBronze3:
                    result = "award_star_bronze_3.png";
                    break;
                case Icon.AwardStarDelete:
                    result = "award_star_delete.png";
                    break;
                case Icon.AwardStarGold1:
                    result = "award_star_gold_1.png";
                    break;
                case Icon.AwardStarGold2:
                    result = "award_star_gold_2.png";
                    break;
                case Icon.AwardStarGold3:
                    result = "award_star_gold_3.png";
                    break;
                case Icon.AwardStarSilver1:
                    result = "award_star_silver_1.png";
                    break;
                case Icon.AwardStarSilver2:
                    result = "award_star_silver_2.png";
                    break;
                case Icon.AwardStarSilver3:
                    result = "award_star_silver_3.png";
                    break;
                case Icon.Basket:
                    result = "basket.png";
                    break;
                case Icon.BasketAdd:
                    result = "basket_add.png";
                    break;
                case Icon.BasketDelete:
                    result = "basket_delete.png";
                    break;
                case Icon.BasketEdit:
                    result = "basket_edit.png";
                    break;
                case Icon.BasketError:
                    result = "basket_error.png";
                    break;
                case Icon.BasketGo:
                    result = "basket_go.png";
                    break;
                case Icon.BasketPut:
                    result = "basket_put.png";
                    break;
                case Icon.BasketRemove:
                    result = "basket_remove.png";
                    break;
                case Icon.Bell:
                    result = "bell.png";
                    break;
                case Icon.BellAdd:
                    result = "bell_add.png";
                    break;
                case Icon.BellDelete:
                    result = "bell_delete.png";
                    break;
                case Icon.BellError:
                    result = "bell_error.png";
                    break;
                case Icon.BellGo:
                    result = "bell_go.png";
                    break;
                case Icon.BellLink:
                    result = "bell_link.png";
                    break;
                case Icon.BellSilver:
                    result = "bell_silver.png";
                    break;
                case Icon.BellSilverStart:
                    result = "bell_silver_start.png";
                    break;
                case Icon.BellSilverStop:
                    result = "bell_silver_stop.png";
                    break;
                case Icon.BellStart:
                    result = "bell_start.png";
                    break;
                case Icon.BellStop:
                    result = "bell_stop.png";
                    break;
                case Icon.Bin:
                    result = "bin.png";
                    break;
                case Icon.BinClosed:
                    result = "bin_closed.png";
                    break;
                case Icon.BinEmpty:
                    result = "bin_empty.png";
                    break;
                case Icon.Blank:
                    result = "blank.png";
                    break;
                case Icon.Bomb:
                    result = "bomb.png";
                    break;
                case Icon.Book:
                    result = "book.png";
                    break;
                case Icon.Bookmark:
                    result = "bookmark.png";
                    break;
                case Icon.BookmarkAdd:
                    result = "bookmark_add.png";
                    break;
                case Icon.BookmarkDelete:
                    result = "bookmark_delete.png";
                    break;
                case Icon.BookmarkEdit:
                    result = "bookmark_edit.png";
                    break;
                case Icon.BookmarkError:
                    result = "bookmark_error.png";
                    break;
                case Icon.BookmarkGo:
                    result = "bookmark_go.png";
                    break;
                case Icon.BookAdd:
                    result = "book_add.png";
                    break;
                case Icon.BookAddresses:
                    result = "book_addresses.png";
                    break;
                case Icon.BookAddressesAdd:
                    result = "book_addresses_add.png";
                    break;
                case Icon.BookAddressesDelete:
                    result = "book_addresses_delete.png";
                    break;
                case Icon.BookAddressesEdit:
                    result = "book_addresses_edit.png";
                    break;
                case Icon.BookAddressesError:
                    result = "book_addresses_error.png";
                    break;
                case Icon.BookAddressesKey:
                    result = "book_addresses_key.png";
                    break;
                case Icon.BookDelete:
                    result = "book_delete.png";
                    break;
                case Icon.BookEdit:
                    result = "book_edit.png";
                    break;
                case Icon.BookError:
                    result = "book_error.png";
                    break;
                case Icon.BookGo:
                    result = "book_go.png";
                    break;
                case Icon.BookKey:
                    result = "book_key.png";
                    break;
                case Icon.BookLink:
                    result = "book_link.png";
                    break;
                case Icon.BookMagnify:
                    result = "book_magnify.png";
                    break;
                case Icon.BookNext:
                    result = "book_next.png";
                    break;
                case Icon.BookOpen:
                    result = "book_open.png";
                    break;
                case Icon.BookOpenMark:
                    result = "book_open_mark.png";
                    break;
                case Icon.BookPrevious:
                    result = "book_previous.png";
                    break;
                case Icon.BookRed:
                    result = "book_red.png";
                    break;
                case Icon.BookTabs:
                    result = "book_tabs.png";
                    break;
                case Icon.BorderAll:
                    result = "border_all.png";
                    break;
                case Icon.BorderBottom:
                    result = "border_bottom.png";
                    break;
                case Icon.BorderDraw:
                    result = "border_draw.png";
                    break;
                case Icon.BorderInner:
                    result = "border_inner.png";
                    break;
                case Icon.BorderInnerHorizontal:
                    result = "border_inner_horizontal.png";
                    break;
                case Icon.BorderInnerVertical:
                    result = "border_inner_vertical.png";
                    break;
                case Icon.BorderLeft:
                    result = "border_left.png";
                    break;
                case Icon.BorderNone:
                    result = "border_none.png";
                    break;
                case Icon.BorderOuter:
                    result = "border_outer.png";
                    break;
                case Icon.BorderRight:
                    result = "border_right.png";
                    break;
                case Icon.BorderTop:
                    result = "border_top.png";
                    break;
                case Icon.Box:
                    result = "box.png";
                    break;
                case Icon.BoxError:
                    result = "box_error.png";
                    break;
                case Icon.BoxPicture:
                    result = "box_picture.png";
                    break;
                case Icon.BoxWorld:
                    result = "box_world.png";
                    break;
                case Icon.Brick:
                    result = "brick.png";
                    break;
                case Icon.Bricks:
                    result = "bricks.png";
                    break;
                case Icon.BrickAdd:
                    result = "brick_add.png";
                    break;
                case Icon.BrickDelete:
                    result = "brick_delete.png";
                    break;
                case Icon.BrickEdit:
                    result = "brick_edit.png";
                    break;
                case Icon.BrickError:
                    result = "brick_error.png";
                    break;
                case Icon.BrickGo:
                    result = "brick_go.png";
                    break;
                case Icon.BrickLink:
                    result = "brick_link.png";
                    break;
                case Icon.BrickMagnify:
                    result = "brick_magnify.png";
                    break;
                case Icon.Briefcase:
                    result = "briefcase.png";
                    break;
                case Icon.Bug:
                    result = "bug.png";
                    break;
                case Icon.BugAdd:
                    result = "bug_add.png";
                    break;
                case Icon.BugDelete:
                    result = "bug_delete.png";
                    break;
                case Icon.BugEdit:
                    result = "bug_edit.png";
                    break;
                case Icon.BugError:
                    result = "bug_error.png";
                    break;
                case Icon.BugFix:
                    result = "bug_fix.png";
                    break;
                case Icon.BugGo:
                    result = "bug_go.png";
                    break;
                case Icon.BugLink:
                    result = "bug_link.png";
                    break;
                case Icon.BugMagnify:
                    result = "bug_magnify.png";
                    break;
                case Icon.Build:
                    result = "build.png";
                    break;
                case Icon.Building:
                    result = "building.png";
                    break;
                case Icon.BuildingAdd:
                    result = "building_add.png";
                    break;
                case Icon.BuildingDelete:
                    result = "building_delete.png";
                    break;
                case Icon.BuildingEdit:
                    result = "building_edit.png";
                    break;
                case Icon.BuildingError:
                    result = "building_error.png";
                    break;
                case Icon.BuildingGo:
                    result = "building_go.png";
                    break;
                case Icon.BuildingKey:
                    result = "building_key.png";
                    break;
                case Icon.BuildingLink:
                    result = "building_link.png";
                    break;
                case Icon.BuildCancel:
                    result = "build_cancel.png";
                    break;
                case Icon.BulletAdd:
                    result = "bullet_add.png";
                    break;
                case Icon.BulletArrowBottom:
                    result = "bullet_arrow_bottom.png";
                    break;
                case Icon.BulletArrowDown:
                    result = "bullet_arrow_down.png";
                    break;
                case Icon.BulletArrowTop:
                    result = "bullet_arrow_top.png";
                    break;
                case Icon.BulletArrowUp:
                    result = "bullet_arrow_up.png";
                    break;
                case Icon.BulletBlack:
                    result = "bullet_black.png";
                    break;
                case Icon.BulletBlue:
                    result = "bullet_blue.png";
                    break;
                case Icon.BulletConnect:
                    result = "bullet_connect.png";
                    break;
                case Icon.BulletCross:
                    result = "bullet_cross.png";
                    break;
                case Icon.BulletDatabase:
                    result = "bullet_database.png";
                    break;
                case Icon.BulletDatabaseYellow:
                    result = "bullet_database_yellow.png";
                    break;
                case Icon.BulletDelete:
                    result = "bullet_delete.png";
                    break;
                case Icon.BulletDisk:
                    result = "bullet_disk.png";
                    break;
                case Icon.BulletEarth:
                    result = "bullet_earth.png";
                    break;
                case Icon.BulletEdit:
                    result = "bullet_edit.png";
                    break;
                case Icon.BulletEject:
                    result = "bullet_eject.png";
                    break;
                case Icon.BulletError:
                    result = "bullet_error.png";
                    break;
                case Icon.BulletFeed:
                    result = "bullet_feed.png";
                    break;
                case Icon.BulletGet:
                    result = "bullet_get.png";
                    break;
                case Icon.BulletGo:
                    result = "bullet_go.png";
                    break;
                case Icon.BulletGreen:
                    result = "bullet_green.png";
                    break;
                case Icon.BulletHome:
                    result = "bullet_home.png";
                    break;
                case Icon.BulletKey:
                    result = "bullet_key.png";
                    break;
                case Icon.BulletLeft:
                    result = "bullet_left.png";
                    break;
                case Icon.BulletLightning:
                    result = "bullet_lightning.png";
                    break;
                case Icon.BulletMagnify:
                    result = "bullet_magnify.png";
                    break;
                case Icon.BulletMinus:
                    result = "bullet_minus.png";
                    break;
                case Icon.BulletOrange:
                    result = "bullet_orange.png";
                    break;
                case Icon.BulletPageWhite:
                    result = "bullet_page_white.png";
                    break;
                case Icon.BulletPicture:
                    result = "bullet_picture.png";
                    break;
                case Icon.BulletPink:
                    result = "bullet_pink.png";
                    break;
                case Icon.BulletPlus:
                    result = "bullet_plus.png";
                    break;
                case Icon.BulletPurple:
                    result = "bullet_purple.png";
                    break;
                case Icon.BulletRed:
                    result = "bullet_red.png";
                    break;
                case Icon.BulletRight:
                    result = "bullet_right.png";
                    break;
                case Icon.BulletShape:
                    result = "bullet_shape.png";
                    break;
                case Icon.BulletSparkle:
                    result = "bullet_sparkle.png";
                    break;
                case Icon.BulletStar:
                    result = "bullet_star.png";
                    break;
                case Icon.BulletStart:
                    result = "bullet_start.png";
                    break;
                case Icon.BulletStop:
                    result = "bullet_stop.png";
                    break;
                case Icon.BulletStopAlt:
                    result = "bullet_stop_alt.png";
                    break;
                case Icon.BulletTick:
                    result = "bullet_tick.png";
                    break;
                case Icon.BulletToggleMinus:
                    result = "bullet_toggle_minus.png";
                    break;
                case Icon.BulletTogglePlus:
                    result = "bullet_toggle_plus.png";
                    break;
                case Icon.BulletWhite:
                    result = "bullet_white.png";
                    break;
                case Icon.BulletWrench:
                    result = "bullet_wrench.png";
                    break;
                case Icon.BulletWrenchRed:
                    result = "bullet_wrench_red.png";
                    break;
                case Icon.BulletYellow:
                    result = "bullet_yellow.png";
                    break;
                case Icon.Button:
                    result = "button.png";
                    break;
                case Icon.Cake:
                    result = "cake.png";
                    break;
                case Icon.CakeOut:
                    result = "cake_out.png";
                    break;
                case Icon.CakeSliced:
                    result = "cake_sliced.png";
                    break;
                case Icon.Calculator:
                    result = "calculator.png";
                    break;
                case Icon.CalculatorAdd:
                    result = "calculator_add.png";
                    break;
                case Icon.CalculatorDelete:
                    result = "calculator_delete.png";
                    break;
                case Icon.CalculatorEdit:
                    result = "calculator_edit.png";
                    break;
                case Icon.CalculatorError:
                    result = "calculator_error.png";
                    break;
                case Icon.CalculatorLink:
                    result = "calculator_link.png";
                    break;
                case Icon.Calendar:
                    result = "calendar.png";
                    break;
                case Icon.CalendarAdd:
                    result = "calendar_add.png";
                    break;
                case Icon.CalendarDelete:
                    result = "calendar_delete.png";
                    break;
                case Icon.CalendarEdit:
                    result = "calendar_edit.png";
                    break;
                case Icon.CalendarLink:
                    result = "calendar_link.png";
                    break;
                case Icon.CalendarSelectDay:
                    result = "calendar_select_day.png";
                    break;
                case Icon.CalendarSelectNone:
                    result = "calendar_select_none.png";
                    break;
                case Icon.CalendarSelectWeek:
                    result = "calendar_select_week.png";
                    break;
                case Icon.CalendarStar:
                    result = "calendar_star.png";
                    break;
                case Icon.CalendarViewDay:
                    result = "calendar_view_day.png";
                    break;
                case Icon.CalendarViewMonth:
                    result = "calendar_view_month.png";
                    break;
                case Icon.CalendarViewWeek:
                    result = "calendar_view_week.png";
                    break;
                case Icon.Camera:
                    result = "camera.png";
                    break;
                case Icon.CameraAdd:
                    result = "camera_add.png";
                    break;
                case Icon.CameraConnect:
                    result = "camera_connect.png";
                    break;
                case Icon.CameraDelete:
                    result = "camera_delete.png";
                    break;
                case Icon.CameraEdit:
                    result = "camera_edit.png";
                    break;
                case Icon.CameraError:
                    result = "camera_error.png";
                    break;
                case Icon.CameraGo:
                    result = "camera_go.png";
                    break;
                case Icon.CameraLink:
                    result = "camera_link.png";
                    break;
                case Icon.CameraMagnify:
                    result = "camera_magnify.png";
                    break;
                case Icon.CameraPicture:
                    result = "camera_picture.png";
                    break;
                case Icon.CameraSmall:
                    result = "camera_small.png";
                    break;
                case Icon.CameraStart:
                    result = "camera_start.png";
                    break;
                case Icon.CameraStop:
                    result = "camera_stop.png";
                    break;
                case Icon.Cancel:
                    result = "cancel.png";
                    break;
                case Icon.Car:
                    result = "car.png";
                    break;
                case Icon.Cart:
                    result = "cart.png";
                    break;
                case Icon.CartAdd:
                    result = "cart_add.png";
                    break;
                case Icon.CartDelete:
                    result = "cart_delete.png";
                    break;
                case Icon.CartEdit:
                    result = "cart_edit.png";
                    break;
                case Icon.CartError:
                    result = "cart_error.png";
                    break;
                case Icon.CartFull:
                    result = "cart_full.png";
                    break;
                case Icon.CartGo:
                    result = "cart_go.png";
                    break;
                case Icon.CartMagnify:
                    result = "cart_magnify.png";
                    break;
                case Icon.CartPut:
                    result = "cart_put.png";
                    break;
                case Icon.CartRemove:
                    result = "cart_remove.png";
                    break;
                case Icon.CarAdd:
                    result = "car_add.png";
                    break;
                case Icon.CarDelete:
                    result = "car_delete.png";
                    break;
                case Icon.CarError:
                    result = "car_error.png";
                    break;
                case Icon.CarRed:
                    result = "car_red.png";
                    break;
                case Icon.CarStart:
                    result = "car_start.png";
                    break;
                case Icon.CarStop:
                    result = "car_stop.png";
                    break;
                case Icon.Cd:
                    result = "cd.png";
                    break;
                case Icon.Cdr:
                    result = "cdr.png";
                    break;
                case Icon.CdrAdd:
                    result = "cdr_add.png";
                    break;
                case Icon.CdrBurn:
                    result = "cdr_burn.png";
                    break;
                case Icon.CdrCross:
                    result = "cdr_cross.png";
                    break;
                case Icon.CdrDelete:
                    result = "cdr_delete.png";
                    break;
                case Icon.CdrEdit:
                    result = "cdr_edit.png";
                    break;
                case Icon.CdrEject:
                    result = "cdr_eject.png";
                    break;
                case Icon.CdrError:
                    result = "cdr_error.png";
                    break;
                case Icon.CdrGo:
                    result = "cdr_go.png";
                    break;
                case Icon.CdrMagnify:
                    result = "cdr_magnify.png";
                    break;
                case Icon.CdrPlay:
                    result = "cdr_play.png";
                    break;
                case Icon.CdrStart:
                    result = "cdr_start.png";
                    break;
                case Icon.CdrStop:
                    result = "cdr_stop.png";
                    break;
                case Icon.CdrStopAlt:
                    result = "cdr_stop_alt.png";
                    break;
                case Icon.CdrTick:
                    result = "cdr_tick.png";
                    break;
                case Icon.CdAdd:
                    result = "cd_add.png";
                    break;
                case Icon.CdBurn:
                    result = "cd_burn.png";
                    break;
                case Icon.CdDelete:
                    result = "cd_delete.png";
                    break;
                case Icon.CdEdit:
                    result = "cd_edit.png";
                    break;
                case Icon.CdEject:
                    result = "cd_eject.png";
                    break;
                case Icon.CdGo:
                    result = "cd_go.png";
                    break;
                case Icon.CdMagnify:
                    result = "cd_magnify.png";
                    break;
                case Icon.CdPlay:
                    result = "cd_play.png";
                    break;
                case Icon.CdStop:
                    result = "cd_stop.png";
                    break;
                case Icon.CdStopAlt:
                    result = "cd_stop_alt.png";
                    break;
                case Icon.CdTick:
                    result = "cd_tick.png";
                    break;
                case Icon.ChartBar:
                    result = "chart_bar.png";
                    break;
                case Icon.ChartBarAdd:
                    result = "chart_bar_add.png";
                    break;
                case Icon.ChartBarDelete:
                    result = "chart_bar_delete.png";
                    break;
                case Icon.ChartBarEdit:
                    result = "chart_bar_edit.png";
                    break;
                case Icon.ChartBarError:
                    result = "chart_bar_error.png";
                    break;
                case Icon.ChartBarLink:
                    result = "chart_bar_link.png";
                    break;
                case Icon.ChartCurve:
                    result = "chart_curve.png";
                    break;
                case Icon.ChartCurveAdd:
                    result = "chart_curve_add.png";
                    break;
                case Icon.ChartCurveDelete:
                    result = "chart_curve_delete.png";
                    break;
                case Icon.ChartCurveEdit:
                    result = "chart_curve_edit.png";
                    break;
                case Icon.ChartCurveError:
                    result = "chart_curve_error.png";
                    break;
                case Icon.ChartCurveGo:
                    result = "chart_curve_go.png";
                    break;
                case Icon.ChartCurveLink:
                    result = "chart_curve_link.png";
                    break;
                case Icon.ChartLine:
                    result = "chart_line.png";
                    break;
                case Icon.ChartLineAdd:
                    result = "chart_line_add.png";
                    break;
                case Icon.ChartLineDelete:
                    result = "chart_line_delete.png";
                    break;
                case Icon.ChartLineEdit:
                    result = "chart_line_edit.png";
                    break;
                case Icon.ChartLineError:
                    result = "chart_line_error.png";
                    break;
                case Icon.ChartLineLink:
                    result = "chart_line_link.png";
                    break;
                case Icon.ChartOrganisation:
                    result = "chart_organisation.png";
                    break;
                case Icon.ChartOrganisationAdd:
                    result = "chart_organisation_add.png";
                    break;
                case Icon.ChartOrganisationDelete:
                    result = "chart_organisation_delete.png";
                    break;
                case Icon.ChartOrgInverted:
                    result = "chart_org_inverted.png";
                    break;
                case Icon.ChartPie:
                    result = "chart_pie.png";
                    break;
                case Icon.ChartPieAdd:
                    result = "chart_pie_add.png";
                    break;
                case Icon.ChartPieDelete:
                    result = "chart_pie_delete.png";
                    break;
                case Icon.ChartPieEdit:
                    result = "chart_pie_edit.png";
                    break;
                case Icon.ChartPieError:
                    result = "chart_pie_error.png";
                    break;
                case Icon.ChartPieLightning:
                    result = "chart_pie_lightning.png";
                    break;
                case Icon.ChartPieLink:
                    result = "chart_pie_link.png";
                    break;
                case Icon.CheckError:
                    result = "check_error.png";
                    break;
                case Icon.Clipboard:
                    result = "clipboard.png";
                    break;
                case Icon.Clock:
                    result = "clock.png";
                    break;
                case Icon.ClockAdd:
                    result = "clock_add.png";
                    break;
                case Icon.ClockDelete:
                    result = "clock_delete.png";
                    break;
                case Icon.ClockEdit:
                    result = "clock_edit.png";
                    break;
                case Icon.ClockError:
                    result = "clock_error.png";
                    break;
                case Icon.ClockGo:
                    result = "clock_go.png";
                    break;
                case Icon.ClockLink:
                    result = "clock_link.png";
                    break;
                case Icon.ClockPause:
                    result = "clock_pause.png";
                    break;
                case Icon.ClockPlay:
                    result = "clock_play.png";
                    break;
                case Icon.ClockRed:
                    result = "clock_red.png";
                    break;
                case Icon.ClockStart:
                    result = "clock_start.png";
                    break;
                case Icon.ClockStop:
                    result = "clock_stop.png";
                    break;
                case Icon.ClockStop2:
                    result = "clock_stop_2.png";
                    break;
                case Icon.Cmy:
                    result = "cmy.png";
                    break;
                case Icon.Cog:
                    result = "cog.png";
                    break;
                case Icon.CogAdd:
                    result = "cog_add.png";
                    break;
                case Icon.CogDelete:
                    result = "cog_delete.png";
                    break;
                case Icon.CogEdit:
                    result = "cog_edit.png";
                    break;
                case Icon.CogError:
                    result = "cog_error.png";
                    break;
                case Icon.CogGo:
                    result = "cog_go.png";
                    break;
                case Icon.CogStart:
                    result = "cog_start.png";
                    break;
                case Icon.CogStop:
                    result = "cog_stop.png";
                    break;
                case Icon.Coins:
                    result = "coins.png";
                    break;
                case Icon.CoinsAdd:
                    result = "coins_add.png";
                    break;
                case Icon.CoinsDelete:
                    result = "coins_delete.png";
                    break;
                case Icon.Color:
                    result = "color.png";
                    break;
                case Icon.ColorSwatch:
                    result = "color_swatch.png";
                    break;
                case Icon.ColorWheel:
                    result = "color_wheel.png";
                    break;
                case Icon.Comment:
                    result = "comment.png";
                    break;
                case Icon.Comments:
                    result = "comments.png";
                    break;
                case Icon.CommentsAdd:
                    result = "comments_add.png";
                    break;
                case Icon.CommentsDelete:
                    result = "comments_delete.png";
                    break;
                case Icon.CommentAdd:
                    result = "comment_add.png";
                    break;
                case Icon.CommentDelete:
                    result = "comment_delete.png";
                    break;
                case Icon.CommentDull:
                    result = "comment_dull.png";
                    break;
                case Icon.CommentEdit:
                    result = "comment_edit.png";
                    break;
                case Icon.CommentPlay:
                    result = "comment_play.png";
                    break;
                case Icon.CommentRecord:
                    result = "comment_record.png";
                    break;
                case Icon.Compass:
                    result = "compass.png";
                    break;
                case Icon.Compress:
                    result = "compress.png";
                    break;
                case Icon.Computer:
                    result = "computer.png";
                    break;
                case Icon.ComputerAdd:
                    result = "computer_add.png";
                    break;
                case Icon.ComputerConnect:
                    result = "computer_connect.png";
                    break;
                case Icon.ComputerDelete:
                    result = "computer_delete.png";
                    break;
                case Icon.ComputerEdit:
                    result = "computer_edit.png";
                    break;
                case Icon.ComputerError:
                    result = "computer_error.png";
                    break;
                case Icon.ComputerGo:
                    result = "computer_go.png";
                    break;
                case Icon.ComputerKey:
                    result = "computer_key.png";
                    break;
                case Icon.ComputerLink:
                    result = "computer_link.png";
                    break;
                case Icon.ComputerMagnify:
                    result = "computer_magnify.png";
                    break;
                case Icon.ComputerOff:
                    result = "computer_off.png";
                    break;
                case Icon.ComputerStart:
                    result = "computer_start.png";
                    break;
                case Icon.ComputerStop:
                    result = "computer_stop.png";
                    break;
                case Icon.ComputerWrench:
                    result = "computer_wrench.png";
                    break;
                case Icon.Connect:
                    result = "connect.png";
                    break;
                case Icon.Contrast:
                    result = "contrast.png";
                    break;
                case Icon.ContrastDecrease:
                    result = "contrast_decrease.png";
                    break;
                case Icon.ContrastHigh:
                    result = "contrast_high.png";
                    break;
                case Icon.ContrastIncrease:
                    result = "contrast_increase.png";
                    break;
                case Icon.ContrastLow:
                    result = "contrast_low.png";
                    break;
                case Icon.Controller:
                    result = "controller.png";
                    break;
                case Icon.ControllerAdd:
                    result = "controller_add.png";
                    break;
                case Icon.ControllerDelete:
                    result = "controller_delete.png";
                    break;
                case Icon.ControllerError:
                    result = "controller_error.png";
                    break;
                case Icon.ControlAdd:
                    result = "control_add.png";
                    break;
                case Icon.ControlAddBlue:
                    result = "control_add_blue.png";
                    break;
                case Icon.ControlBlank:
                    result = "control_blank.png";
                    break;
                case Icon.ControlBlankBlue:
                    result = "control_blank_blue.png";
                    break;
                case Icon.ControlEject:
                    result = "control_eject.png";
                    break;
                case Icon.ControlEjectBlue:
                    result = "control_eject_blue.png";
                    break;
                case Icon.ControlEnd:
                    result = "control_end.png";
                    break;
                case Icon.ControlEndBlue:
                    result = "control_end_blue.png";
                    break;
                case Icon.ControlEqualizer:
                    result = "control_equalizer.png";
                    break;
                case Icon.ControlEqualizerBlue:
                    result = "control_equalizer_blue.png";
                    break;
                case Icon.ControlFastforward:
                    result = "control_fastforward.png";
                    break;
                case Icon.ControlFastforwardBlue:
                    result = "control_fastforward_blue.png";
                    break;
                case Icon.ControlPause:
                    result = "control_pause.png";
                    break;
                case Icon.ControlPauseBlue:
                    result = "control_pause_blue.png";
                    break;
                case Icon.ControlPlay:
                    result = "control_play.png";
                    break;
                case Icon.ControlPlayBlue:
                    result = "control_play_blue.png";
                    break;
                case Icon.ControlPower:
                    result = "control_power.png";
                    break;
                case Icon.ControlPowerBlue:
                    result = "control_power_blue.png";
                    break;
                case Icon.ControlRecord:
                    result = "control_record.png";
                    break;
                case Icon.ControlRecordBlue:
                    result = "control_record_blue.png";
                    break;
                case Icon.ControlRemove:
                    result = "control_remove.png";
                    break;
                case Icon.ControlRemoveBlue:
                    result = "control_remove_blue.png";
                    break;
                case Icon.ControlRepeat:
                    result = "control_repeat.png";
                    break;
                case Icon.ControlRepeatBlue:
                    result = "control_repeat_blue.png";
                    break;
                case Icon.ControlRewind:
                    result = "control_rewind.png";
                    break;
                case Icon.ControlRewindBlue:
                    result = "control_rewind_blue.png";
                    break;
                case Icon.ControlStart:
                    result = "control_start.png";
                    break;
                case Icon.ControlStartBlue:
                    result = "control_start_blue.png";
                    break;
                case Icon.ControlStop:
                    result = "control_stop.png";
                    break;
                case Icon.ControlStopBlue:
                    result = "control_stop_blue.png";
                    break;
                case Icon.Creditcards:
                    result = "creditcards.png";
                    break;
                case Icon.Cross:
                    result = "cross.png";
                    break;
                case Icon.Css:
                    result = "css.png";
                    break;
                case Icon.CssAdd:
                    result = "css_add.png";
                    break;
                case Icon.CssDelete:
                    result = "css_delete.png";
                    break;
                case Icon.CssError:
                    result = "css_error.png";
                    break;
                case Icon.CssGo:
                    result = "css_go.png";
                    break;
                case Icon.CssValid:
                    result = "css_valid.png";
                    break;
                case Icon.Cup:
                    result = "cup.png";
                    break;
                case Icon.CupAdd:
                    result = "cup_add.png";
                    break;
                case Icon.CupBlack:
                    result = "cup_black.png";
                    break;
                case Icon.CupDelete:
                    result = "cup_delete.png";
                    break;
                case Icon.CupEdit:
                    result = "cup_edit.png";
                    break;
                case Icon.CupError:
                    result = "cup_error.png";
                    break;
                case Icon.CupGo:
                    result = "cup_go.png";
                    break;
                case Icon.CupGreen:
                    result = "cup_green.png";
                    break;
                case Icon.CupKey:
                    result = "cup_key.png";
                    break;
                case Icon.CupLink:
                    result = "cup_link.png";
                    break;
                case Icon.CupTea:
                    result = "cup_tea.png";
                    break;
                case Icon.Cursor:
                    result = "cursor.png";
                    break;
                case Icon.CursorSmall:
                    result = "cursor_small.png";
                    break;
                case Icon.Cut:
                    result = "cut.png";
                    break;
                case Icon.CutRed:
                    result = "cut_red.png";
                    break;
                case Icon.Database:
                    result = "database.png";
                    break;
                case Icon.DatabaseAdd:
                    result = "database_add.png";
                    break;
                case Icon.DatabaseConnect:
                    result = "database_connect.png";
                    break;
                case Icon.DatabaseCopy:
                    result = "database_copy.png";
                    break;
                case Icon.DatabaseDelete:
                    result = "database_delete.png";
                    break;
                case Icon.DatabaseEdit:
                    result = "database_edit.png";
                    break;
                case Icon.DatabaseError:
                    result = "database_error.png";
                    break;
                case Icon.DatabaseGear:
                    result = "database_gear.png";
                    break;
                case Icon.DatabaseGo:
                    result = "database_go.png";
                    break;
                case Icon.DatabaseKey:
                    result = "database_key.png";
                    break;
                case Icon.DatabaseLightning:
                    result = "database_lightning.png";
                    break;
                case Icon.DatabaseLink:
                    result = "database_link.png";
                    break;
                case Icon.DatabaseRefresh:
                    result = "database_refresh.png";
                    break;
                case Icon.DatabaseSave:
                    result = "database_save.png";
                    break;
                case Icon.DatabaseStart:
                    result = "database_start.png";
                    break;
                case Icon.DatabaseStop:
                    result = "database_stop.png";
                    break;
                case Icon.DatabaseTable:
                    result = "database_table.png";
                    break;
                case Icon.DatabaseWrench:
                    result = "database_wrench.png";
                    break;
                case Icon.DatabaseYellow:
                    result = "database_yellow.png";
                    break;
                case Icon.DatabaseYellowStart:
                    result = "database_yellow_start.png";
                    break;
                case Icon.DatabaseYellowStop:
                    result = "database_yellow_stop.png";
                    break;
                case Icon.Date:
                    result = "date.png";
                    break;
                case Icon.DateAdd:
                    result = "date_add.png";
                    break;
                case Icon.DateDelete:
                    result = "date_delete.png";
                    break;
                case Icon.DateEdit:
                    result = "date_edit.png";
                    break;
                case Icon.DateError:
                    result = "date_error.png";
                    break;
                case Icon.DateGo:
                    result = "date_go.png";
                    break;
                case Icon.DateLink:
                    result = "date_link.png";
                    break;
                case Icon.DateMagnify:
                    result = "date_magnify.png";
                    break;
                case Icon.DateNext:
                    result = "date_next.png";
                    break;
                case Icon.DatePrevious:
                    result = "date_previous.png";
                    break;
                case Icon.Decline:
                    result = "decline.png";
                    break;
                case Icon.Delete:
                    result = "delete.png";
                    break;
                case Icon.DeviceStylus:
                    result = "device_stylus.png";
                    break;
                case Icon.Disconnect:
                    result = "disconnect.png";
                    break;
                case Icon.Disk:
                    result = "disk.png";
                    break;
                case Icon.DiskBlack:
                    result = "disk_black.png";
                    break;
                case Icon.DiskBlackError:
                    result = "disk_black_error.png";
                    break;
                case Icon.DiskBlackMagnify:
                    result = "disk_black_magnify.png";
                    break;
                case Icon.DiskDownload:
                    result = "disk_download.png";
                    break;
                case Icon.DiskEdit:
                    result = "disk_edit.png";
                    break;
                case Icon.DiskError:
                    result = "disk_error.png";
                    break;
                case Icon.DiskMagnify:
                    result = "disk_magnify.png";
                    break;
                case Icon.DiskMultiple:
                    result = "disk_multiple.png";
                    break;
                case Icon.DiskUpload:
                    result = "disk_upload.png";
                    break;
                case Icon.Door:
                    result = "door.png";
                    break;
                case Icon.DoorError:
                    result = "door_error.png";
                    break;
                case Icon.DoorIn:
                    result = "door_in.png";
                    break;
                case Icon.DoorOpen:
                    result = "door_open.png";
                    break;
                case Icon.DoorOut:
                    result = "door_out.png";
                    break;
                case Icon.Drink:
                    result = "drink.png";
                    break;
                case Icon.DrinkEmpty:
                    result = "drink_empty.png";
                    break;
                case Icon.DrinkRed:
                    result = "drink_red.png";
                    break;
                case Icon.Drive:
                    result = "drive.png";
                    break;
                case Icon.DriveAdd:
                    result = "drive_add.png";
                    break;
                case Icon.DriveBurn:
                    result = "drive_burn.png";
                    break;
                case Icon.DriveCd:
                    result = "drive_cd.png";
                    break;
                case Icon.DriveCdr:
                    result = "drive_cdr.png";
                    break;
                case Icon.DriveCdEmpty:
                    result = "drive_cd_empty.png";
                    break;
                case Icon.DriveDelete:
                    result = "drive_delete.png";
                    break;
                case Icon.DriveDisk:
                    result = "drive_disk.png";
                    break;
                case Icon.DriveEdit:
                    result = "drive_edit.png";
                    break;
                case Icon.DriveError:
                    result = "drive_error.png";
                    break;
                case Icon.DriveGo:
                    result = "drive_go.png";
                    break;
                case Icon.DriveKey:
                    result = "drive_key.png";
                    break;
                case Icon.DriveLink:
                    result = "drive_link.png";
                    break;
                case Icon.DriveMagnify:
                    result = "drive_magnify.png";
                    break;
                case Icon.DriveNetwork:
                    result = "drive_network.png";
                    break;
                case Icon.DriveNetworkError:
                    result = "drive_network_error.png";
                    break;
                case Icon.DriveNetworkStop:
                    result = "drive_network_stop.png";
                    break;
                case Icon.DriveRename:
                    result = "drive_rename.png";
                    break;
                case Icon.DriveUser:
                    result = "drive_user.png";
                    break;
                case Icon.DriveWeb:
                    result = "drive_web.png";
                    break;
                case Icon.Dvd:
                    result = "dvd.png";
                    break;
                case Icon.DvdAdd:
                    result = "dvd_add.png";
                    break;
                case Icon.DvdDelete:
                    result = "dvd_delete.png";
                    break;
                case Icon.DvdEdit:
                    result = "dvd_edit.png";
                    break;
                case Icon.DvdError:
                    result = "dvd_error.png";
                    break;
                case Icon.DvdGo:
                    result = "dvd_go.png";
                    break;
                case Icon.DvdKey:
                    result = "dvd_key.png";
                    break;
                case Icon.DvdLink:
                    result = "dvd_link.png";
                    break;
                case Icon.DvdStart:
                    result = "dvd_start.png";
                    break;
                case Icon.DvdStop:
                    result = "dvd_stop.png";
                    break;
                case Icon.EjectBlue:
                    result = "eject_blue.png";
                    break;
                case Icon.EjectGreen:
                    result = "eject_green.png";
                    break;
                case Icon.Email:
                    result = "email.png";
                    break;
                case Icon.EmailAdd:
                    result = "email_add.png";
                    break;
                case Icon.EmailAttach:
                    result = "email_attach.png";
                    break;
                case Icon.EmailDelete:
                    result = "email_delete.png";
                    break;
                case Icon.EmailEdit:
                    result = "email_edit.png";
                    break;
                case Icon.EmailError:
                    result = "email_error.png";
                    break;
                case Icon.EmailGo:
                    result = "email_go.png";
                    break;
                case Icon.EmailLink:
                    result = "email_link.png";
                    break;
                case Icon.EmailMagnify:
                    result = "email_magnify.png";
                    break;
                case Icon.EmailOpen:
                    result = "email_open.png";
                    break;
                case Icon.EmailOpenImage:
                    result = "email_open_image.png";
                    break;
                case Icon.EmailStar:
                    result = "email_star.png";
                    break;
                case Icon.EmailStart:
                    result = "email_start.png";
                    break;
                case Icon.EmailStop:
                    result = "email_stop.png";
                    break;
                case Icon.EmailTransfer:
                    result = "email_transfer.png";
                    break;
                case Icon.EmoticonEvilgrin:
                    result = "emoticon_evilgrin.png";
                    break;
                case Icon.EmoticonGrin:
                    result = "emoticon_grin.png";
                    break;
                case Icon.EmoticonHappy:
                    result = "emoticon_happy.png";
                    break;
                case Icon.EmoticonSmile:
                    result = "emoticon_smile.png";
                    break;
                case Icon.EmoticonSurprised:
                    result = "emoticon_surprised.png";
                    break;
                case Icon.EmoticonTongue:
                    result = "emoticon_tongue.png";
                    break;
                case Icon.EmoticonUnhappy:
                    result = "emoticon_unhappy.png";
                    break;
                case Icon.EmoticonWaii:
                    result = "emoticon_waii.png";
                    break;
                case Icon.EmoticonWink:
                    result = "emoticon_wink.png";
                    break;
                case Icon.Erase:
                    result = "erase.png";
                    break;
                case Icon.Error:
                    result = "error.png";
                    break;
                case Icon.ErrorAdd:
                    result = "error_add.png";
                    break;
                case Icon.ErrorDelete:
                    result = "error_delete.png";
                    break;
                case Icon.ErrorGo:
                    result = "error_go.png";
                    break;
                case Icon.Exclamation:
                    result = "exclamation.png";
                    break;
                case Icon.Eye:
                    result = "eye.png";
                    break;
                case Icon.Eyes:
                    result = "eyes.png";
                    break;
                case Icon.Feed:
                    result = "feed.png";
                    break;
                case Icon.FeedAdd:
                    result = "feed_add.png";
                    break;
                case Icon.FeedDelete:
                    result = "feed_delete.png";
                    break;
                case Icon.FeedDisk:
                    result = "feed_disk.png";
                    break;
                case Icon.FeedEdit:
                    result = "feed_edit.png";
                    break;
                case Icon.FeedError:
                    result = "feed_error.png";
                    break;
                case Icon.FeedGo:
                    result = "feed_go.png";
                    break;
                case Icon.FeedKey:
                    result = "feed_key.png";
                    break;
                case Icon.FeedLink:
                    result = "feed_link.png";
                    break;
                case Icon.FeedMagnify:
                    result = "feed_magnify.png";
                    break;
                case Icon.FeedStar:
                    result = "feed_star.png";
                    break;
                case Icon.Female:
                    result = "female.png";
                    break;
                case Icon.Film:
                    result = "film.png";
                    break;
                case Icon.FilmAdd:
                    result = "film_add.png";
                    break;
                case Icon.FilmDelete:
                    result = "film_delete.png";
                    break;
                case Icon.FilmEdit:
                    result = "film_edit.png";
                    break;
                case Icon.FilmEject:
                    result = "film_eject.png";
                    break;
                case Icon.FilmError:
                    result = "film_error.png";
                    break;
                case Icon.FilmGo:
                    result = "film_go.png";
                    break;
                case Icon.FilmKey:
                    result = "film_key.png";
                    break;
                case Icon.FilmLink:
                    result = "film_link.png";
                    break;
                case Icon.FilmMagnify:
                    result = "film_magnify.png";
                    break;
                case Icon.FilmSave:
                    result = "film_save.png";
                    break;
                case Icon.FilmStar:
                    result = "film_star.png";
                    break;
                case Icon.FilmStart:
                    result = "film_start.png";
                    break;
                case Icon.FilmStop:
                    result = "film_stop.png";
                    break;
                case Icon.Find:
                    result = "find.png";
                    break;
                case Icon.FingerPoint:
                    result = "finger_point.png";
                    break;
                case Icon.FlagAd:
                    result = "flag_ad.png";
                    break;
                case Icon.FlagAe:
                    result = "flag_ae.png";
                    break;
                case Icon.FlagAf:
                    result = "flag_af.png";
                    break;
                case Icon.FlagAg:
                    result = "flag_ag.png";
                    break;
                case Icon.FlagAi:
                    result = "flag_ai.png";
                    break;
                case Icon.FlagAl:
                    result = "flag_al.png";
                    break;
                case Icon.FlagAm:
                    result = "flag_am.png";
                    break;
                case Icon.FlagAn:
                    result = "flag_an.png";
                    break;
                case Icon.FlagAo:
                    result = "flag_ao.png";
                    break;
                case Icon.FlagAr:
                    result = "flag_ar.png";
                    break;
                case Icon.FlagAs:
                    result = "flag_as.png";
                    break;
                case Icon.FlagAt:
                    result = "flag_at.png";
                    break;
                case Icon.FlagAu:
                    result = "flag_au.png";
                    break;
                case Icon.FlagAw:
                    result = "flag_aw.png";
                    break;
                case Icon.FlagAx:
                    result = "flag_ax.png";
                    break;
                case Icon.FlagAz:
                    result = "flag_az.png";
                    break;
                case Icon.FlagBa:
                    result = "flag_ba.png";
                    break;
                case Icon.FlagBb:
                    result = "flag_bb.png";
                    break;
                case Icon.FlagBd:
                    result = "flag_bd.png";
                    break;
                case Icon.FlagBe:
                    result = "flag_be.png";
                    break;
                case Icon.FlagBf:
                    result = "flag_bf.png";
                    break;
                case Icon.FlagBg:
                    result = "flag_bg.png";
                    break;
                case Icon.FlagBh:
                    result = "flag_bh.png";
                    break;
                case Icon.FlagBi:
                    result = "flag_bi.png";
                    break;
                case Icon.FlagBj:
                    result = "flag_bj.png";
                    break;
                case Icon.FlagBlack:
                    result = "flag_black.png";
                    break;
                case Icon.FlagBlue:
                    result = "flag_blue.png";
                    break;
                case Icon.FlagBm:
                    result = "flag_bm.png";
                    break;
                case Icon.FlagBn:
                    result = "flag_bn.png";
                    break;
                case Icon.FlagBo:
                    result = "flag_bo.png";
                    break;
                case Icon.FlagBr:
                    result = "flag_br.png";
                    break;
                case Icon.FlagBs:
                    result = "flag_bs.png";
                    break;
                case Icon.FlagBt:
                    result = "flag_bt.png";
                    break;
                case Icon.FlagBv:
                    result = "flag_bv.png";
                    break;
                case Icon.FlagBw:
                    result = "flag_bw.png";
                    break;
                case Icon.FlagBy:
                    result = "flag_by.png";
                    break;
                case Icon.FlagBz:
                    result = "flag_bz.png";
                    break;
                case Icon.FlagCa:
                    result = "flag_ca.png";
                    break;
                case Icon.FlagCatalonia:
                    result = "flag_catalonia.png";
                    break;
                case Icon.FlagCc:
                    result = "flag_cc.png";
                    break;
                case Icon.FlagCd:
                    result = "flag_cd.png";
                    break;
                case Icon.FlagCf:
                    result = "flag_cf.png";
                    break;
                case Icon.FlagCg:
                    result = "flag_cg.png";
                    break;
                case Icon.FlagCh:
                    result = "flag_ch.png";
                    break;
                case Icon.FlagChecked:
                    result = "flag_checked.png";
                    break;
                case Icon.FlagCi:
                    result = "flag_ci.png";
                    break;
                case Icon.FlagCk:
                    result = "flag_ck.png";
                    break;
                case Icon.FlagCl:
                    result = "flag_cl.png";
                    break;
                case Icon.FlagCm:
                    result = "flag_cm.png";
                    break;
                case Icon.FlagCn:
                    result = "flag_cn.png";
                    break;
                case Icon.FlagCo:
                    result = "flag_co.png";
                    break;
                case Icon.FlagCr:
                    result = "flag_cr.png";
                    break;
                case Icon.FlagCs:
                    result = "flag_cs.png";
                    break;
                case Icon.FlagCu:
                    result = "flag_cu.png";
                    break;
                case Icon.FlagCv:
                    result = "flag_cv.png";
                    break;
                case Icon.FlagCx:
                    result = "flag_cx.png";
                    break;
                case Icon.FlagCy:
                    result = "flag_cy.png";
                    break;
                case Icon.FlagCz:
                    result = "flag_cz.png";
                    break;
                case Icon.FlagDe:
                    result = "flag_de.png";
                    break;
                case Icon.FlagDj:
                    result = "flag_dj.png";
                    break;
                case Icon.FlagDk:
                    result = "flag_dk.png";
                    break;
                case Icon.FlagDm:
                    result = "flag_dm.png";
                    break;
                case Icon.FlagDo:
                    result = "flag_do.png";
                    break;
                case Icon.FlagDz:
                    result = "flag_dz.png";
                    break;
                case Icon.FlagEc:
                    result = "flag_ec.png";
                    break;
                case Icon.FlagEe:
                    result = "flag_ee.png";
                    break;
                case Icon.FlagEg:
                    result = "flag_eg.png";
                    break;
                case Icon.FlagEh:
                    result = "flag_eh.png";
                    break;
                case Icon.FlagEngland:
                    result = "flag_england.png";
                    break;
                case Icon.FlagEr:
                    result = "flag_er.png";
                    break;
                case Icon.FlagEs:
                    result = "flag_es.png";
                    break;
                case Icon.FlagEt:
                    result = "flag_et.png";
                    break;
                case Icon.FlagEuropeanunion:
                    result = "flag_europeanunion.png";
                    break;
                case Icon.FlagFam:
                    result = "flag_fam.png";
                    break;
                case Icon.FlagFi:
                    result = "flag_fi.png";
                    break;
                case Icon.FlagFj:
                    result = "flag_fj.png";
                    break;
                case Icon.FlagFk:
                    result = "flag_fk.png";
                    break;
                case Icon.FlagFm:
                    result = "flag_fm.png";
                    break;
                case Icon.FlagFo:
                    result = "flag_fo.png";
                    break;
                case Icon.FlagFr:
                    result = "flag_fr.png";
                    break;
                case Icon.FlagFrance:
                    result = "flag_france.png";
                    break;
                case Icon.FlagGa:
                    result = "flag_ga.png";
                    break;
                case Icon.FlagGb:
                    result = "flag_gb.png";
                    break;
                case Icon.FlagGd:
                    result = "flag_gd.png";
                    break;
                case Icon.FlagGe:
                    result = "flag_ge.png";
                    break;
                case Icon.FlagGf:
                    result = "flag_gf.png";
                    break;
                case Icon.FlagGg:
                    result = "flag_gg.png";
                    break;
                case Icon.FlagGh:
                    result = "flag_gh.png";
                    break;
                case Icon.FlagGi:
                    result = "flag_gi.png";
                    break;
                case Icon.FlagGl:
                    result = "flag_gl.png";
                    break;
                case Icon.FlagGm:
                    result = "flag_gm.png";
                    break;
                case Icon.FlagGn:
                    result = "flag_gn.png";
                    break;
                case Icon.FlagGp:
                    result = "flag_gp.png";
                    break;
                case Icon.FlagGq:
                    result = "flag_gq.png";
                    break;
                case Icon.FlagGr:
                    result = "flag_gr.png";
                    break;
                case Icon.FlagGreen:
                    result = "flag_green.png";
                    break;
                case Icon.FlagGrey:
                    result = "flag_grey.png";
                    break;
                case Icon.FlagGs:
                    result = "flag_gs.png";
                    break;
                case Icon.FlagGt:
                    result = "flag_gt.png";
                    break;
                case Icon.FlagGu:
                    result = "flag_gu.png";
                    break;
                case Icon.FlagGw:
                    result = "flag_gw.png";
                    break;
                case Icon.FlagGy:
                    result = "flag_gy.png";
                    break;
                case Icon.FlagHk:
                    result = "flag_hk.png";
                    break;
                case Icon.FlagHm:
                    result = "flag_hm.png";
                    break;
                case Icon.FlagHn:
                    result = "flag_hn.png";
                    break;
                case Icon.FlagHr:
                    result = "flag_hr.png";
                    break;
                case Icon.FlagHt:
                    result = "flag_ht.png";
                    break;
                case Icon.FlagHu:
                    result = "flag_hu.png";
                    break;
                case Icon.FlagId:
                    result = "flag_id.png";
                    break;
                case Icon.FlagIe:
                    result = "flag_ie.png";
                    break;
                case Icon.FlagIl:
                    result = "flag_il.png";
                    break;
                case Icon.FlagIn:
                    result = "flag_in.png";
                    break;
                case Icon.FlagIo:
                    result = "flag_io.png";
                    break;
                case Icon.FlagIq:
                    result = "flag_iq.png";
                    break;
                case Icon.FlagIr:
                    result = "flag_ir.png";
                    break;
                case Icon.FlagIs:
                    result = "flag_is.png";
                    break;
                case Icon.FlagIt:
                    result = "flag_it.png";
                    break;
                case Icon.FlagJm:
                    result = "flag_jm.png";
                    break;
                case Icon.FlagJo:
                    result = "flag_jo.png";
                    break;
                case Icon.FlagJp:
                    result = "flag_jp.png";
                    break;
                case Icon.FlagKe:
                    result = "flag_ke.png";
                    break;
                case Icon.FlagKg:
                    result = "flag_kg.png";
                    break;
                case Icon.FlagKh:
                    result = "flag_kh.png";
                    break;
                case Icon.FlagKi:
                    result = "flag_ki.png";
                    break;
                case Icon.FlagKm:
                    result = "flag_km.png";
                    break;
                case Icon.FlagKn:
                    result = "flag_kn.png";
                    break;
                case Icon.FlagKp:
                    result = "flag_kp.png";
                    break;
                case Icon.FlagKr:
                    result = "flag_kr.png";
                    break;
                case Icon.FlagKw:
                    result = "flag_kw.png";
                    break;
                case Icon.FlagKy:
                    result = "flag_ky.png";
                    break;
                case Icon.FlagKz:
                    result = "flag_kz.png";
                    break;
                case Icon.FlagLa:
                    result = "flag_la.png";
                    break;
                case Icon.FlagLb:
                    result = "flag_lb.png";
                    break;
                case Icon.FlagLc:
                    result = "flag_lc.png";
                    break;
                case Icon.FlagLi:
                    result = "flag_li.png";
                    break;
                case Icon.FlagLk:
                    result = "flag_lk.png";
                    break;
                case Icon.FlagLr:
                    result = "flag_lr.png";
                    break;
                case Icon.FlagLs:
                    result = "flag_ls.png";
                    break;
                case Icon.FlagLt:
                    result = "flag_lt.png";
                    break;
                case Icon.FlagLu:
                    result = "flag_lu.png";
                    break;
                case Icon.FlagLv:
                    result = "flag_lv.png";
                    break;
                case Icon.FlagLy:
                    result = "flag_ly.png";
                    break;
                case Icon.FlagMa:
                    result = "flag_ma.png";
                    break;
                case Icon.FlagMc:
                    result = "flag_mc.png";
                    break;
                case Icon.FlagMd:
                    result = "flag_md.png";
                    break;
                case Icon.FlagMe:
                    result = "flag_me.png";
                    break;
                case Icon.FlagMg:
                    result = "flag_mg.png";
                    break;
                case Icon.FlagMh:
                    result = "flag_mh.png";
                    break;
                case Icon.FlagMk:
                    result = "flag_mk.png";
                    break;
                case Icon.FlagMl:
                    result = "flag_ml.png";
                    break;
                case Icon.FlagMm:
                    result = "flag_mm.png";
                    break;
                case Icon.FlagMn:
                    result = "flag_mn.png";
                    break;
                case Icon.FlagMo:
                    result = "flag_mo.png";
                    break;
                case Icon.FlagMp:
                    result = "flag_mp.png";
                    break;
                case Icon.FlagMq:
                    result = "flag_mq.png";
                    break;
                case Icon.FlagMr:
                    result = "flag_mr.png";
                    break;
                case Icon.FlagMs:
                    result = "flag_ms.png";
                    break;
                case Icon.FlagMt:
                    result = "flag_mt.png";
                    break;
                case Icon.FlagMu:
                    result = "flag_mu.png";
                    break;
                case Icon.FlagMv:
                    result = "flag_mv.png";
                    break;
                case Icon.FlagMw:
                    result = "flag_mw.png";
                    break;
                case Icon.FlagMx:
                    result = "flag_mx.png";
                    break;
                case Icon.FlagMy:
                    result = "flag_my.png";
                    break;
                case Icon.FlagMz:
                    result = "flag_mz.png";
                    break;
                case Icon.FlagNa:
                    result = "flag_na.png";
                    break;
                case Icon.FlagNc:
                    result = "flag_nc.png";
                    break;
                case Icon.FlagNe:
                    result = "flag_ne.png";
                    break;
                case Icon.FlagNf:
                    result = "flag_nf.png";
                    break;
                case Icon.FlagNg:
                    result = "flag_ng.png";
                    break;
                case Icon.FlagNi:
                    result = "flag_ni.png";
                    break;
                case Icon.FlagNl:
                    result = "flag_nl.png";
                    break;
                case Icon.FlagNo:
                    result = "flag_no.png";
                    break;
                case Icon.FlagNp:
                    result = "flag_np.png";
                    break;
                case Icon.FlagNr:
                    result = "flag_nr.png";
                    break;
                case Icon.FlagNu:
                    result = "flag_nu.png";
                    break;
                case Icon.FlagNz:
                    result = "flag_nz.png";
                    break;
                case Icon.FlagOm:
                    result = "flag_om.png";
                    break;
                case Icon.FlagOrange:
                    result = "flag_orange.png";
                    break;
                case Icon.FlagPa:
                    result = "flag_pa.png";
                    break;
                case Icon.FlagPe:
                    result = "flag_pe.png";
                    break;
                case Icon.FlagPf:
                    result = "flag_pf.png";
                    break;
                case Icon.FlagPg:
                    result = "flag_pg.png";
                    break;
                case Icon.FlagPh:
                    result = "flag_ph.png";
                    break;
                case Icon.FlagPink:
                    result = "flag_pink.png";
                    break;
                case Icon.FlagPk:
                    result = "flag_pk.png";
                    break;
                case Icon.FlagPl:
                    result = "flag_pl.png";
                    break;
                case Icon.FlagPm:
                    result = "flag_pm.png";
                    break;
                case Icon.FlagPn:
                    result = "flag_pn.png";
                    break;
                case Icon.FlagPr:
                    result = "flag_pr.png";
                    break;
                case Icon.FlagPs:
                    result = "flag_ps.png";
                    break;
                case Icon.FlagPt:
                    result = "flag_pt.png";
                    break;
                case Icon.FlagPurple:
                    result = "flag_purple.png";
                    break;
                case Icon.FlagPw:
                    result = "flag_pw.png";
                    break;
                case Icon.FlagPy:
                    result = "flag_py.png";
                    break;
                case Icon.FlagQa:
                    result = "flag_qa.png";
                    break;
                case Icon.FlagRe:
                    result = "flag_re.png";
                    break;
                case Icon.FlagRed:
                    result = "flag_red.png";
                    break;
                case Icon.FlagRo:
                    result = "flag_ro.png";
                    break;
                case Icon.FlagRs:
                    result = "flag_rs.png";
                    break;
                case Icon.FlagRu:
                    result = "flag_ru.png";
                    break;
                case Icon.FlagRw:
                    result = "flag_rw.png";
                    break;
                case Icon.FlagSa:
                    result = "flag_sa.png";
                    break;
                case Icon.FlagSb:
                    result = "flag_sb.png";
                    break;
                case Icon.FlagSc:
                    result = "flag_sc.png";
                    break;
                case Icon.FlagScotland:
                    result = "flag_scotland.png";
                    break;
                case Icon.FlagSd:
                    result = "flag_sd.png";
                    break;
                case Icon.FlagSe:
                    result = "flag_se.png";
                    break;
                case Icon.FlagSg:
                    result = "flag_sg.png";
                    break;
                case Icon.FlagSh:
                    result = "flag_sh.png";
                    break;
                case Icon.FlagSi:
                    result = "flag_si.png";
                    break;
                case Icon.FlagSj:
                    result = "flag_sj.png";
                    break;
                case Icon.FlagSk:
                    result = "flag_sk.png";
                    break;
                case Icon.FlagSl:
                    result = "flag_sl.png";
                    break;
                case Icon.FlagSm:
                    result = "flag_sm.png";
                    break;
                case Icon.FlagSn:
                    result = "flag_sn.png";
                    break;
                case Icon.FlagSo:
                    result = "flag_so.png";
                    break;
                case Icon.FlagSr:
                    result = "flag_sr.png";
                    break;
                case Icon.FlagSt:
                    result = "flag_st.png";
                    break;
                case Icon.FlagSv:
                    result = "flag_sv.png";
                    break;
                case Icon.FlagSy:
                    result = "flag_sy.png";
                    break;
                case Icon.FlagSz:
                    result = "flag_sz.png";
                    break;
                case Icon.FlagTc:
                    result = "flag_tc.png";
                    break;
                case Icon.FlagTd:
                    result = "flag_td.png";
                    break;
                case Icon.FlagTf:
                    result = "flag_tf.png";
                    break;
                case Icon.FlagTg:
                    result = "flag_tg.png";
                    break;
                case Icon.FlagTh:
                    result = "flag_th.png";
                    break;
                case Icon.FlagTj:
                    result = "flag_tj.png";
                    break;
                case Icon.FlagTk:
                    result = "flag_tk.png";
                    break;
                case Icon.FlagTl:
                    result = "flag_tl.png";
                    break;
                case Icon.FlagTm:
                    result = "flag_tm.png";
                    break;
                case Icon.FlagTn:
                    result = "flag_tn.png";
                    break;
                case Icon.FlagTo:
                    result = "flag_to.png";
                    break;
                case Icon.FlagTr:
                    result = "flag_tr.png";
                    break;
                case Icon.FlagTt:
                    result = "flag_tt.png";
                    break;
                case Icon.FlagTv:
                    result = "flag_tv.png";
                    break;
                case Icon.FlagTw:
                    result = "flag_tw.png";
                    break;
                case Icon.FlagTz:
                    result = "flag_tz.png";
                    break;
                case Icon.FlagUa:
                    result = "flag_ua.png";
                    break;
                case Icon.FlagUg:
                    result = "flag_ug.png";
                    break;
                case Icon.FlagUm:
                    result = "flag_um.png";
                    break;
                case Icon.FlagUs:
                    result = "flag_us.png";
                    break;
                case Icon.FlagUy:
                    result = "flag_uy.png";
                    break;
                case Icon.FlagUz:
                    result = "flag_uz.png";
                    break;
                case Icon.FlagVa:
                    result = "flag_va.png";
                    break;
                case Icon.FlagVc:
                    result = "flag_vc.png";
                    break;
                case Icon.FlagVe:
                    result = "flag_ve.png";
                    break;
                case Icon.FlagVg:
                    result = "flag_vg.png";
                    break;
                case Icon.FlagVi:
                    result = "flag_vi.png";
                    break;
                case Icon.FlagVn:
                    result = "flag_vn.png";
                    break;
                case Icon.FlagVu:
                    result = "flag_vu.png";
                    break;
                case Icon.FlagWales:
                    result = "flag_wales.png";
                    break;
                case Icon.FlagWf:
                    result = "flag_wf.png";
                    break;
                case Icon.FlagWhite:
                    result = "flag_white.png";
                    break;
                case Icon.FlagWs:
                    result = "flag_ws.png";
                    break;
                case Icon.FlagYe:
                    result = "flag_ye.png";
                    break;
                case Icon.FlagYellow:
                    result = "flag_yellow.png";
                    break;
                case Icon.FlagYt:
                    result = "flag_yt.png";
                    break;
                case Icon.FlagZa:
                    result = "flag_za.png";
                    break;
                case Icon.FlagZm:
                    result = "flag_zm.png";
                    break;
                case Icon.FlagZw:
                    result = "flag_zw.png";
                    break;
                case Icon.FlowerDaisy:
                    result = "flower_daisy.png";
                    break;
                case Icon.Folder:
                    result = "folder.png";
                    break;
                case Icon.FolderAdd:
                    result = "folder_add.png";
                    break;
                case Icon.FolderBell:
                    result = "folder_bell.png";
                    break;
                case Icon.FolderBookmark:
                    result = "folder_bookmark.png";
                    break;
                case Icon.FolderBrick:
                    result = "folder_brick.png";
                    break;
                case Icon.FolderBug:
                    result = "folder_bug.png";
                    break;
                case Icon.FolderCamera:
                    result = "folder_camera.png";
                    break;
                case Icon.FolderConnect:
                    result = "folder_connect.png";
                    break;
                case Icon.FolderDatabase:
                    result = "folder_database.png";
                    break;
                case Icon.FolderDelete:
                    result = "folder_delete.png";
                    break;
                case Icon.FolderEdit:
                    result = "folder_edit.png";
                    break;
                case Icon.FolderError:
                    result = "folder_error.png";
                    break;
                case Icon.FolderExplore:
                    result = "folder_explore.png";
                    break;
                case Icon.FolderFeed:
                    result = "folder_feed.png";
                    break;
                case Icon.FolderFilm:
                    result = "folder_film.png";
                    break;
                case Icon.FolderFind:
                    result = "folder_find.png";
                    break;
                case Icon.FolderFont:
                    result = "folder_font.png";
                    break;
                case Icon.FolderGo:
                    result = "folder_go.png";
                    break;
                case Icon.FolderHeart:
                    result = "folder_heart.png";
                    break;
                case Icon.FolderHome:
                    result = "folder_home.png";
                    break;
                case Icon.FolderImage:
                    result = "folder_image.png";
                    break;
                case Icon.FolderKey:
                    result = "folder_key.png";
                    break;
                case Icon.FolderLightbulb:
                    result = "folder_lightbulb.png";
                    break;
                case Icon.FolderLink:
                    result = "folder_link.png";
                    break;
                case Icon.FolderMagnify:
                    result = "folder_magnify.png";
                    break;
                case Icon.FolderPage:
                    result = "folder_page.png";
                    break;
                case Icon.FolderPageWhite:
                    result = "folder_page_white.png";
                    break;
                case Icon.FolderPalette:
                    result = "folder_palette.png";
                    break;
                case Icon.FolderPicture:
                    result = "folder_picture.png";
                    break;
                case Icon.FolderStar:
                    result = "folder_star.png";
                    break;
                case Icon.FolderTable:
                    result = "folder_table.png";
                    break;
                case Icon.FolderUp:
                    result = "folder_up.png";
                    break;
                case Icon.FolderUser:
                    result = "folder_user.png";
                    break;
                case Icon.FolderWrench:
                    result = "folder_wrench.png";
                    break;
                case Icon.Font:
                    result = "font.png";
                    break;
                case Icon.FontAdd:
                    result = "font_add.png";
                    break;
                case Icon.FontColor:
                    result = "font_color.png";
                    break;
                case Icon.FontDelete:
                    result = "font_delete.png";
                    break;
                case Icon.FontGo:
                    result = "font_go.png";
                    break;
                case Icon.FontLarger:
                    result = "font_larger.png";
                    break;
                case Icon.FontSmaller:
                    result = "font_smaller.png";
                    break;
                case Icon.ForwardBlue:
                    result = "forward_blue.png";
                    break;
                case Icon.ForwardGreen:
                    result = "forward_green.png";
                    break;
                case Icon.Group:
                    result = "group.png";
                    break;
                case Icon.GroupAdd:
                    result = "group_add.png";
                    break;
                case Icon.GroupDelete:
                    result = "group_delete.png";
                    break;
                case Icon.GroupEdit:
                    result = "group_edit.png";
                    break;
                case Icon.GroupError:
                    result = "group_error.png";
                    break;
                case Icon.GroupGear:
                    result = "group_gear.png";
                    break;
                case Icon.GroupGo:
                    result = "group_go.png";
                    break;
                case Icon.GroupKey:
                    result = "group_key.png";
                    break;
                case Icon.GroupLink:
                    result = "group_link.png";
                    break;
                case Icon.Heart:
                    result = "heart.png";
                    break;
                case Icon.HeartAdd:
                    result = "heart_add.png";
                    break;
                case Icon.HeartBroken:
                    result = "heart_broken.png";
                    break;
                case Icon.HeartConnect:
                    result = "heart_connect.png";
                    break;
                case Icon.HeartDelete:
                    result = "heart_delete.png";
                    break;
                case Icon.Help:
                    result = "help.png";
                    break;
                case Icon.Hourglass:
                    result = "hourglass.png";
                    break;
                case Icon.HourglassAdd:
                    result = "hourglass_add.png";
                    break;
                case Icon.HourglassDelete:
                    result = "hourglass_delete.png";
                    break;
                case Icon.HourglassGo:
                    result = "hourglass_go.png";
                    break;
                case Icon.HourglassLink:
                    result = "hourglass_link.png";
                    break;
                case Icon.House:
                    result = "house.png";
                    break;
                case Icon.HouseConnect:
                    result = "house_connect.png";
                    break;
                case Icon.HouseGo:
                    result = "house_go.png";
                    break;
                case Icon.HouseKey:
                    result = "house_key.png";
                    break;
                case Icon.HouseLink:
                    result = "house_link.png";
                    break;
                case Icon.HouseStar:
                    result = "house_star.png";
                    break;
                case Icon.Html:
                    result = "html.png";
                    break;
                case Icon.HtmlAdd:
                    result = "html_add.png";
                    break;
                case Icon.HtmlDelete:
                    result = "html_delete.png";
                    break;
                case Icon.HtmlError:
                    result = "html_error.png";
                    break;
                case Icon.HtmlGo:
                    result = "html_go.png";
                    break;
                case Icon.HtmlValid:
                    result = "html_valid.png";
                    break;
                case Icon.Image:
                    result = "image.png";
                    break;
                case Icon.Images:
                    result = "images.png";
                    break;
                case Icon.ImageAdd:
                    result = "image_add.png";
                    break;
                case Icon.ImageDelete:
                    result = "image_delete.png";
                    break;
                case Icon.ImageEdit:
                    result = "image_edit.png";
                    break;
                case Icon.ImageLink:
                    result = "image_link.png";
                    break;
                case Icon.ImageMagnify:
                    result = "image_magnify.png";
                    break;
                case Icon.ImageStar:
                    result = "image_star.png";
                    break;
                case Icon.Information:
                    result = "information.png";
                    break;
                case Icon.Ipod:
                    result = "ipod.png";
                    break;
                case Icon.IpodCast:
                    result = "ipod_cast.png";
                    break;
                case Icon.IpodCastAdd:
                    result = "ipod_cast_add.png";
                    break;
                case Icon.IpodCastDelete:
                    result = "ipod_cast_delete.png";
                    break;
                case Icon.IpodConnect:
                    result = "ipod_connect.png";
                    break;
                case Icon.IpodNano:
                    result = "ipod_nano.png";
                    break;
                case Icon.IpodNanoConnect:
                    result = "ipod_nano_connect.png";
                    break;
                case Icon.IpodSound:
                    result = "ipod_sound.png";
                    break;
                case Icon.Joystick:
                    result = "joystick.png";
                    break;
                case Icon.JoystickAdd:
                    result = "joystick_add.png";
                    break;
                case Icon.JoystickConnect:
                    result = "joystick_connect.png";
                    break;
                case Icon.JoystickDelete:
                    result = "joystick_delete.png";
                    break;
                case Icon.JoystickError:
                    result = "joystick_error.png";
                    break;
                case Icon.Key:
                    result = "key.png";
                    break;
                case Icon.Keyboard:
                    result = "keyboard.png";
                    break;
                case Icon.KeyboardAdd:
                    result = "keyboard_add.png";
                    break;
                case Icon.KeyboardConnect:
                    result = "keyboard_connect.png";
                    break;
                case Icon.KeyboardDelete:
                    result = "keyboard_delete.png";
                    break;
                case Icon.KeyboardMagnify:
                    result = "keyboard_magnify.png";
                    break;
                case Icon.KeyAdd:
                    result = "key_add.png";
                    break;
                case Icon.KeyDelete:
                    result = "key_delete.png";
                    break;
                case Icon.KeyGo:
                    result = "key_go.png";
                    break;
                case Icon.KeyStart:
                    result = "key_start.png";
                    break;
                case Icon.KeyStop:
                    result = "key_stop.png";
                    break;
                case Icon.Laptop:
                    result = "laptop.png";
                    break;
                case Icon.LaptopAdd:
                    result = "laptop_add.png";
                    break;
                case Icon.LaptopConnect:
                    result = "laptop_connect.png";
                    break;
                case Icon.LaptopDelete:
                    result = "laptop_delete.png";
                    break;
                case Icon.LaptopDisk:
                    result = "laptop_disk.png";
                    break;
                case Icon.LaptopEdit:
                    result = "laptop_edit.png";
                    break;
                case Icon.LaptopError:
                    result = "laptop_error.png";
                    break;
                case Icon.LaptopGo:
                    result = "laptop_go.png";
                    break;
                case Icon.LaptopKey:
                    result = "laptop_key.png";
                    break;
                case Icon.LaptopLink:
                    result = "laptop_link.png";
                    break;
                case Icon.LaptopMagnify:
                    result = "laptop_magnify.png";
                    break;
                case Icon.LaptopStart:
                    result = "laptop_start.png";
                    break;
                case Icon.LaptopStop:
                    result = "laptop_stop.png";
                    break;
                case Icon.LaptopWrench:
                    result = "laptop_wrench.png";
                    break;
                case Icon.Layers:
                    result = "layers.png";
                    break;
                case Icon.Layout:
                    result = "layout.png";
                    break;
                case Icon.LayoutAdd:
                    result = "layout_add.png";
                    break;
                case Icon.LayoutContent:
                    result = "layout_content.png";
                    break;
                case Icon.LayoutDelete:
                    result = "layout_delete.png";
                    break;
                case Icon.LayoutEdit:
                    result = "layout_edit.png";
                    break;
                case Icon.LayoutError:
                    result = "layout_error.png";
                    break;
                case Icon.LayoutHeader:
                    result = "layout_header.png";
                    break;
                case Icon.LayoutKey:
                    result = "layout_key.png";
                    break;
                case Icon.LayoutLightning:
                    result = "layout_lightning.png";
                    break;
                case Icon.LayoutLink:
                    result = "layout_link.png";
                    break;
                case Icon.LayoutSidebar:
                    result = "layout_sidebar.png";
                    break;
                case Icon.Lightbulb:
                    result = "lightbulb.png";
                    break;
                case Icon.LightbulbAdd:
                    result = "lightbulb_add.png";
                    break;
                case Icon.LightbulbDelete:
                    result = "lightbulb_delete.png";
                    break;
                case Icon.LightbulbOff:
                    result = "lightbulb_off.png";
                    break;
                case Icon.Lightning:
                    result = "lightning.png";
                    break;
                case Icon.LightningAdd:
                    result = "lightning_add.png";
                    break;
                case Icon.LightningDelete:
                    result = "lightning_delete.png";
                    break;
                case Icon.LightningGo:
                    result = "lightning_go.png";
                    break;
                case Icon.Link:
                    result = "link.png";
                    break;
                case Icon.LinkAdd:
                    result = "link_add.png";
                    break;
                case Icon.LinkBreak:
                    result = "link_break.png";
                    break;
                case Icon.LinkDelete:
                    result = "link_delete.png";
                    break;
                case Icon.LinkEdit:
                    result = "link_edit.png";
                    break;
                case Icon.LinkError:
                    result = "link_error.png";
                    break;
                case Icon.LinkGo:
                    result = "link_go.png";
                    break;
                case Icon.Lock:
                    result = "lock.png";
                    break;
                case Icon.LockAdd:
                    result = "lock_add.png";
                    break;
                case Icon.LockBreak:
                    result = "lock_break.png";
                    break;
                case Icon.LockDelete:
                    result = "lock_delete.png";
                    break;
                case Icon.LockEdit:
                    result = "lock_edit.png";
                    break;
                case Icon.LockGo:
                    result = "lock_go.png";
                    break;
                case Icon.LockKey:
                    result = "lock_key.png";
                    break;
                case Icon.LockOpen:
                    result = "lock_open.png";
                    break;
                case Icon.LockStart:
                    result = "lock_start.png";
                    break;
                case Icon.LockStop:
                    result = "lock_stop.png";
                    break;
                case Icon.Lorry:
                    result = "lorry.png";
                    break;
                case Icon.LorryAdd:
                    result = "lorry_add.png";
                    break;
                case Icon.LorryDelete:
                    result = "lorry_delete.png";
                    break;
                case Icon.LorryError:
                    result = "lorry_error.png";
                    break;
                case Icon.LorryFlatbed:
                    result = "lorry_flatbed.png";
                    break;
                case Icon.LorryGo:
                    result = "lorry_go.png";
                    break;
                case Icon.LorryLink:
                    result = "lorry_link.png";
                    break;
                case Icon.LorryStart:
                    result = "lorry_start.png";
                    break;
                case Icon.LorryStop:
                    result = "lorry_stop.png";
                    break;
                case Icon.MagifierZoomOut:
                    result = "magifier_zoom_out.png";
                    break;
                case Icon.Magnifier:
                    result = "magnifier.png";
                    break;
                case Icon.MagnifierZoomIn:
                    result = "magnifier_zoom_in.png";
                    break;
                case Icon.Mail:
                    result = "mail.png";
                    break;
                case Icon.Male:
                    result = "male.png";
                    break;
                case Icon.Map:
                    result = "map.png";
                    break;
                case Icon.MapAdd:
                    result = "map_add.png";
                    break;
                case Icon.MapClipboard:
                    result = "map_clipboard.png";
                    break;
                case Icon.MapCursor:
                    result = "map_cursor.png";
                    break;
                case Icon.MapDelete:
                    result = "map_delete.png";
                    break;
                case Icon.MapEdit:
                    result = "map_edit.png";
                    break;
                case Icon.MapError:
                    result = "map_error.png";
                    break;
                case Icon.MapGo:
                    result = "map_go.png";
                    break;
                case Icon.MapLink:
                    result = "map_link.png";
                    break;
                case Icon.MapMagnify:
                    result = "map_magnify.png";
                    break;
                case Icon.MapStart:
                    result = "map_start.png";
                    break;
                case Icon.MapStop:
                    result = "map_stop.png";
                    break;
                case Icon.MedalBronze1:
                    result = "medal_bronze_1.png";
                    break;
                case Icon.MedalBronze2:
                    result = "medal_bronze_2.png";
                    break;
                case Icon.MedalBronze3:
                    result = "medal_bronze_3.png";
                    break;
                case Icon.MedalBronzeAdd:
                    result = "medal_bronze_add.png";
                    break;
                case Icon.MedalBronzeDelete:
                    result = "medal_bronze_delete.png";
                    break;
                case Icon.MedalGold1:
                    result = "medal_gold_1.png";
                    break;
                case Icon.MedalGold2:
                    result = "medal_gold_2.png";
                    break;
                case Icon.MedalGold3:
                    result = "medal_gold_3.png";
                    break;
                case Icon.MedalGoldAdd:
                    result = "medal_gold_add.png";
                    break;
                case Icon.MedalGoldDelete:
                    result = "medal_gold_delete.png";
                    break;
                case Icon.MedalSilver1:
                    result = "medal_silver_1.png";
                    break;
                case Icon.MedalSilver2:
                    result = "medal_silver_2.png";
                    break;
                case Icon.MedalSilver3:
                    result = "medal_silver_3.png";
                    break;
                case Icon.MedalSilverAdd:
                    result = "medal_silver_add.png";
                    break;
                case Icon.MedalSilverDelete:
                    result = "medal_silver_delete.png";
                    break;
                case Icon.Money:
                    result = "money.png";
                    break;
                case Icon.MoneyAdd:
                    result = "money_add.png";
                    break;
                case Icon.MoneyDelete:
                    result = "money_delete.png";
                    break;
                case Icon.MoneyDollar:
                    result = "money_dollar.png";
                    break;
                case Icon.MoneyEuro:
                    result = "money_euro.png";
                    break;
                case Icon.MoneyPound:
                    result = "money_pound.png";
                    break;
                case Icon.MoneyYen:
                    result = "money_yen.png";
                    break;
                case Icon.Monitor:
                    result = "monitor.png";
                    break;
                case Icon.MonitorAdd:
                    result = "monitor_add.png";
                    break;
                case Icon.MonitorDelete:
                    result = "monitor_delete.png";
                    break;
                case Icon.MonitorEdit:
                    result = "monitor_edit.png";
                    break;
                case Icon.MonitorError:
                    result = "monitor_error.png";
                    break;
                case Icon.MonitorGo:
                    result = "monitor_go.png";
                    break;
                case Icon.MonitorKey:
                    result = "monitor_key.png";
                    break;
                case Icon.MonitorLightning:
                    result = "monitor_lightning.png";
                    break;
                case Icon.MonitorLink:
                    result = "monitor_link.png";
                    break;
                case Icon.MoonFull:
                    result = "moon_full.png";
                    break;
                case Icon.Mouse:
                    result = "mouse.png";
                    break;
                case Icon.MouseAdd:
                    result = "mouse_add.png";
                    break;
                case Icon.MouseDelete:
                    result = "mouse_delete.png";
                    break;
                case Icon.MouseError:
                    result = "mouse_error.png";
                    break;
                case Icon.Music:
                    result = "music.png";
                    break;
                case Icon.MusicNote:
                    result = "music_note.png";
                    break;
                case Icon.Neighbourhood:
                    result = "neighbourhood.png";
                    break;
                case Icon.New:
                    result = "new.png";
                    break;
                case Icon.Newspaper:
                    result = "newspaper.png";
                    break;
                case Icon.NewspaperAdd:
                    result = "newspaper_add.png";
                    break;
                case Icon.NewspaperDelete:
                    result = "newspaper_delete.png";
                    break;
                case Icon.NewspaperGo:
                    result = "newspaper_go.png";
                    break;
                case Icon.NewspaperLink:
                    result = "newspaper_link.png";
                    break;
                case Icon.NewBlue:
                    result = "new_blue.png";
                    break;
                case Icon.NewRed:
                    result = "new_red.png";
                    break;
                case Icon.NextBlue:
                    result = "next_blue.png";
                    break;
                case Icon.NextGreen:
                    result = "next_green.png";
                    break;
                case Icon.Note:
                    result = "note.png";
                    break;
                case Icon.NoteAdd:
                    result = "note_add.png";
                    break;
                case Icon.NoteDelete:
                    result = "note_delete.png";
                    break;
                case Icon.NoteEdit:
                    result = "note_edit.png";
                    break;
                case Icon.NoteError:
                    result = "note_error.png";
                    break;
                case Icon.NoteGo:
                    result = "note_go.png";
                    break;
                case Icon.Outline:
                    result = "outline.png";
                    break;
                case Icon.Overlays:
                    result = "overlays.png";
                    break;
                case Icon.Package:
                    result = "package.png";
                    break;
                case Icon.PackageAdd:
                    result = "package_add.png";
                    break;
                case Icon.PackageDelete:
                    result = "package_delete.png";
                    break;
                case Icon.PackageDown:
                    result = "package_down.png";
                    break;
                case Icon.PackageGo:
                    result = "package_go.png";
                    break;
                case Icon.PackageGreen:
                    result = "package_green.png";
                    break;
                case Icon.PackageIn:
                    result = "package_in.png";
                    break;
                case Icon.PackageLink:
                    result = "package_link.png";
                    break;
                case Icon.PackageSe:
                    result = "package_se.png";
                    break;
                case Icon.PackageStart:
                    result = "package_start.png";
                    break;
                case Icon.PackageStop:
                    result = "package_stop.png";
                    break;
                case Icon.PackageWhite:
                    result = "package_white.png";
                    break;
                case Icon.Page:
                    result = "page.png";
                    break;
                case Icon.PageAdd:
                    result = "page_add.png";
                    break;
                case Icon.PageAttach:
                    result = "page_attach.png";
                    break;
                case Icon.PageBack:
                    result = "page_back.png";
                    break;
                case Icon.PageBreak:
                    result = "page_break.png";
                    break;
                case Icon.PageBreakInsert:
                    result = "page_break_insert.png";
                    break;
                case Icon.PageCancel:
                    result = "page_cancel.png";
                    break;
                case Icon.PageCode:
                    result = "page_code.png";
                    break;
                case Icon.PageCopy:
                    result = "page_copy.png";
                    break;
                case Icon.PageDelete:
                    result = "page_delete.png";
                    break;
                case Icon.PageEdit:
                    result = "page_edit.png";
                    break;
                case Icon.PageError:
                    result = "page_error.png";
                    break;
                case Icon.PageExcel:
                    result = "page_excel.png";
                    break;
                case Icon.PageFind:
                    result = "page_find.png";
                    break;
                case Icon.PageForward:
                    result = "page_forward.png";
                    break;
                case Icon.PageGear:
                    result = "page_gear.png";
                    break;
                case Icon.PageGo:
                    result = "page_go.png";
                    break;
                case Icon.PageGreen:
                    result = "page_green.png";
                    break;
                case Icon.PageHeaderFooter:
                    result = "page_header_footer.png";
                    break;
                case Icon.PageKey:
                    result = "page_key.png";
                    break;
                case Icon.PageLandscape:
                    result = "page_landscape.png";
                    break;
                case Icon.PageLandscapeShot:
                    result = "page_landscape_shot.png";
                    break;
                case Icon.PageLightning:
                    result = "page_lightning.png";
                    break;
                case Icon.PageLink:
                    result = "page_link.png";
                    break;
                case Icon.PageMagnify:
                    result = "page_magnify.png";
                    break;
                case Icon.PagePaintbrush:
                    result = "page_paintbrush.png";
                    break;
                case Icon.PagePaste:
                    result = "page_paste.png";
                    break;
                case Icon.PagePortrait:
                    result = "page_portrait.png";
                    break;
                case Icon.PagePortraitShot:
                    result = "page_portrait_shot.png";
                    break;
                case Icon.PageRed:
                    result = "page_red.png";
                    break;
                case Icon.PageRefresh:
                    result = "page_refresh.png";
                    break;
                case Icon.PageSave:
                    result = "page_save.png";
                    break;
                case Icon.PageWhite:
                    result = "page_white.png";
                    break;
                case Icon.PageWhiteAcrobat:
                    result = "page_white_acrobat.png";
                    break;
                case Icon.PageWhiteActionscript:
                    result = "page_white_actionscript.png";
                    break;
                case Icon.PageWhiteAdd:
                    result = "page_white_add.png";
                    break;
                case Icon.PageWhiteBreak:
                    result = "page_white_break.png";
                    break;
                case Icon.PageWhiteC:
                    result = "page_white_c.png";
                    break;
                case Icon.PageWhiteCamera:
                    result = "page_white_camera.png";
                    break;
                case Icon.PageWhiteCd:
                    result = "page_white_cd.png";
                    break;
                case Icon.PageWhiteCdr:
                    result = "page_white_cdr.png";
                    break;
                case Icon.PageWhiteCode:
                    result = "page_white_code.png";
                    break;
                case Icon.PageWhiteCodeRed:
                    result = "page_white_code_red.png";
                    break;
                case Icon.PageWhiteColdfusion:
                    result = "page_white_coldfusion.png";
                    break;
                case Icon.PageWhiteCompressed:
                    result = "page_white_compressed.png";
                    break;
                case Icon.PageWhiteConnect:
                    result = "page_white_connect.png";
                    break;
                case Icon.PageWhiteCopy:
                    result = "page_white_copy.png";
                    break;
                case Icon.PageWhiteCplusplus:
                    result = "page_white_cplusplus.png";
                    break;
                case Icon.PageWhiteCsharp:
                    result = "page_white_csharp.png";
                    break;
                case Icon.PageWhiteCup:
                    result = "page_white_cup.png";
                    break;
                case Icon.PageWhiteDatabase:
                    result = "page_white_database.png";
                    break;
                case Icon.PageWhiteDatabaseYellow:
                    result = "page_white_database_yellow.png";
                    break;
                case Icon.PageWhiteDelete:
                    result = "page_white_delete.png";
                    break;
                case Icon.PageWhiteDvd:
                    result = "page_white_dvd.png";
                    break;
                case Icon.PageWhiteEdit:
                    result = "page_white_edit.png";
                    break;
                case Icon.PageWhiteError:
                    result = "page_white_error.png";
                    break;
                case Icon.PageWhiteExcel:
                    result = "page_white_excel.png";
                    break;
                case Icon.PageWhiteFind:
                    result = "page_white_find.png";
                    break;
                case Icon.PageWhiteFlash:
                    result = "page_white_flash.png";
                    break;
                case Icon.PageWhiteFont:
                    result = "page_white_font.png";
                    break;
                case Icon.PageWhiteFreehand:
                    result = "page_white_freehand.png";
                    break;
                case Icon.PageWhiteGear:
                    result = "page_white_gear.png";
                    break;
                case Icon.PageWhiteGet:
                    result = "page_white_get.png";
                    break;
                case Icon.PageWhiteGo:
                    result = "page_white_go.png";
                    break;
                case Icon.PageWhiteH:
                    result = "page_white_h.png";
                    break;
                case Icon.PageWhiteHorizontal:
                    result = "page_white_horizontal.png";
                    break;
                case Icon.PageWhiteKey:
                    result = "page_white_key.png";
                    break;
                case Icon.PageWhiteLightning:
                    result = "page_white_lightning.png";
                    break;
                case Icon.PageWhiteLink:
                    result = "page_white_link.png";
                    break;
                case Icon.PageWhiteMagnify:
                    result = "page_white_magnify.png";
                    break;
                case Icon.PageWhiteMedal:
                    result = "page_white_medal.png";
                    break;
                case Icon.PageWhiteOffice:
                    result = "page_white_office.png";
                    break;
                case Icon.PageWhitePaint:
                    result = "page_white_paint.png";
                    break;
                case Icon.PageWhitePaintbrush:
                    result = "page_white_paintbrush.png";
                    break;
                case Icon.PageWhitePaint2:
                    result = "page_white_paint_2.png";
                    break;
                case Icon.PageWhitePaste:
                    result = "page_white_paste.png";
                    break;
                case Icon.PageWhitePasteTable:
                    result = "page_white_paste_table.png";
                    break;
                case Icon.PageWhitePhp:
                    result = "page_white_php.png";
                    break;
                case Icon.PageWhitePicture:
                    result = "page_white_picture.png";
                    break;
                case Icon.PageWhitePowerpoint:
                    result = "page_white_powerpoint.png";
                    break;
                case Icon.PageWhitePut:
                    result = "page_white_put.png";
                    break;
                case Icon.PageWhiteRefresh:
                    result = "page_white_refresh.png";
                    break;
                case Icon.PageWhiteRuby:
                    result = "page_white_ruby.png";
                    break;
                case Icon.PageWhiteSideBySide:
                    result = "page_white_side_by_side.png";
                    break;
                case Icon.PageWhiteStack:
                    result = "page_white_stack.png";
                    break;
                case Icon.PageWhiteStar:
                    result = "page_white_star.png";
                    break;
                case Icon.PageWhiteSwoosh:
                    result = "page_white_swoosh.png";
                    break;
                case Icon.PageWhiteText:
                    result = "page_white_text.png";
                    break;
                case Icon.PageWhiteTextWidth:
                    result = "page_white_text_width.png";
                    break;
                case Icon.PageWhiteTux:
                    result = "page_white_tux.png";
                    break;
                case Icon.PageWhiteVector:
                    result = "page_white_vector.png";
                    break;
                case Icon.PageWhiteVisualstudio:
                    result = "page_white_visualstudio.png";
                    break;
                case Icon.PageWhiteWidth:
                    result = "page_white_width.png";
                    break;
                case Icon.PageWhiteWord:
                    result = "page_white_word.png";
                    break;
                case Icon.PageWhiteWorld:
                    result = "page_white_world.png";
                    break;
                case Icon.PageWhiteWrench:
                    result = "page_white_wrench.png";
                    break;
                case Icon.PageWhiteZip:
                    result = "page_white_zip.png";
                    break;
                case Icon.PageWord:
                    result = "page_word.png";
                    break;
                case Icon.PageWorld:
                    result = "page_world.png";
                    break;
                case Icon.Paint:
                    result = "paint.png";
                    break;
                case Icon.Paintbrush:
                    result = "paintbrush.png";
                    break;
                case Icon.PaintbrushColor:
                    result = "paintbrush_color.png";
                    break;
                case Icon.Paintcan:
                    result = "paintcan.png";
                    break;
                case Icon.PaintcanRed:
                    result = "paintcan_red.png";
                    break;
                case Icon.PaintCanBrush:
                    result = "paint_can_brush.png";
                    break;
                case Icon.Palette:
                    result = "palette.png";
                    break;
                case Icon.PastePlain:
                    result = "paste_plain.png";
                    break;
                case Icon.PasteWord:
                    result = "paste_word.png";
                    break;
                case Icon.PauseBlue:
                    result = "pause_blue.png";
                    break;
                case Icon.PauseGreen:
                    result = "pause_green.png";
                    break;
                case Icon.PauseRecord:
                    result = "pause_record.png";
                    break;
                case Icon.Pencil:
                    result = "pencil.png";
                    break;
                case Icon.PencilAdd:
                    result = "pencil_add.png";
                    break;
                case Icon.PencilDelete:
                    result = "pencil_delete.png";
                    break;
                case Icon.PencilGo:
                    result = "pencil_go.png";
                    break;
                case Icon.Phone:
                    result = "phone.png";
                    break;
                case Icon.PhoneAdd:
                    result = "phone_add.png";
                    break;
                case Icon.PhoneDelete:
                    result = "phone_delete.png";
                    break;
                case Icon.PhoneEdit:
                    result = "phone_edit.png";
                    break;
                case Icon.PhoneError:
                    result = "phone_error.png";
                    break;
                case Icon.PhoneGo:
                    result = "phone_go.png";
                    break;
                case Icon.PhoneKey:
                    result = "phone_key.png";
                    break;
                case Icon.PhoneLink:
                    result = "phone_link.png";
                    break;
                case Icon.PhoneSound:
                    result = "phone_sound.png";
                    break;
                case Icon.PhoneStart:
                    result = "phone_start.png";
                    break;
                case Icon.PhoneStop:
                    result = "phone_stop.png";
                    break;
                case Icon.Photo:
                    result = "photo.png";
                    break;
                case Icon.Photos:
                    result = "photos.png";
                    break;
                case Icon.PhotoAdd:
                    result = "photo_add.png";
                    break;
                case Icon.PhotoDelete:
                    result = "photo_delete.png";
                    break;
                case Icon.PhotoEdit:
                    result = "photo_edit.png";
                    break;
                case Icon.PhotoLink:
                    result = "photo_link.png";
                    break;
                case Icon.PhotoPaint:
                    result = "photo_paint.png";
                    break;
                case Icon.Picture:
                    result = "picture.png";
                    break;
                case Icon.Pictures:
                    result = "pictures.png";
                    break;
                case Icon.PicturesThumbs:
                    result = "pictures_thumbs.png";
                    break;
                case Icon.PictureAdd:
                    result = "picture_add.png";
                    break;
                case Icon.PictureClipboard:
                    result = "picture_clipboard.png";
                    break;
                case Icon.PictureDelete:
                    result = "picture_delete.png";
                    break;
                case Icon.PictureEdit:
                    result = "picture_edit.png";
                    break;
                case Icon.PictureEmpty:
                    result = "picture_empty.png";
                    break;
                case Icon.PictureError:
                    result = "picture_error.png";
                    break;
                case Icon.PictureGo:
                    result = "picture_go.png";
                    break;
                case Icon.PictureKey:
                    result = "picture_key.png";
                    break;
                case Icon.PictureLink:
                    result = "picture_link.png";
                    break;
                case Icon.PictureSave:
                    result = "picture_save.png";
                    break;
                case Icon.Pilcrow:
                    result = "pilcrow.png";
                    break;
                case Icon.Pill:
                    result = "pill.png";
                    break;
                case Icon.PillAdd:
                    result = "pill_add.png";
                    break;
                case Icon.PillDelete:
                    result = "pill_delete.png";
                    break;
                case Icon.PillError:
                    result = "pill_error.png";
                    break;
                case Icon.PillGo:
                    result = "pill_go.png";
                    break;
                case Icon.PlayBlue:
                    result = "play_blue.png";
                    break;
                case Icon.PlayGreen:
                    result = "play_green.png";
                    break;
                case Icon.Plugin:
                    result = "plugin.png";
                    break;
                case Icon.PluginAdd:
                    result = "plugin_add.png";
                    break;
                case Icon.PluginDelete:
                    result = "plugin_delete.png";
                    break;
                case Icon.PluginDisabled:
                    result = "plugin_disabled.png";
                    break;
                case Icon.PluginEdit:
                    result = "plugin_edit.png";
                    break;
                case Icon.PluginError:
                    result = "plugin_error.png";
                    break;
                case Icon.PluginGo:
                    result = "plugin_go.png";
                    break;
                case Icon.PluginKey:
                    result = "plugin_key.png";
                    break;
                case Icon.PluginLink:
                    result = "plugin_link.png";
                    break;
                case Icon.PreviousGreen:
                    result = "previous_green.png";
                    break;
                case Icon.Printer:
                    result = "printer.png";
                    break;
                case Icon.PrinterAdd:
                    result = "printer_add.png";
                    break;
                case Icon.PrinterCancel:
                    result = "printer_cancel.png";
                    break;
                case Icon.PrinterColor:
                    result = "printer_color.png";
                    break;
                case Icon.PrinterConnect:
                    result = "printer_connect.png";
                    break;
                case Icon.PrinterDelete:
                    result = "printer_delete.png";
                    break;
                case Icon.PrinterEmpty:
                    result = "printer_empty.png";
                    break;
                case Icon.PrinterError:
                    result = "printer_error.png";
                    break;
                case Icon.PrinterGo:
                    result = "printer_go.png";
                    break;
                case Icon.PrinterKey:
                    result = "printer_key.png";
                    break;
                case Icon.PrinterMono:
                    result = "printer_mono.png";
                    break;
                case Icon.PrinterStart:
                    result = "printer_start.png";
                    break;
                case Icon.PrinterStop:
                    result = "printer_stop.png";
                    break;
                case Icon.Rainbow:
                    result = "rainbow.png";
                    break;
                case Icon.RainbowStar:
                    result = "rainbow_star.png";
                    break;
                case Icon.RecordBlue:
                    result = "record_blue.png";
                    break;
                case Icon.RecordGreen:
                    result = "record_green.png";
                    break;
                case Icon.RecordRed:
                    result = "record_red.png";
                    break;
                case Icon.Reload:
                    result = "reload.png";
                    break;
                case Icon.Report:
                    result = "report.png";
                    break;
                case Icon.ReportAdd:
                    result = "report_add.png";
                    break;
                case Icon.ReportDelete:
                    result = "report_delete.png";
                    break;
                case Icon.ReportDisk:
                    result = "report_disk.png";
                    break;
                case Icon.ReportEdit:
                    result = "report_edit.png";
                    break;
                case Icon.ReportGo:
                    result = "report_go.png";
                    break;
                case Icon.ReportKey:
                    result = "report_key.png";
                    break;
                case Icon.ReportLink:
                    result = "report_link.png";
                    break;
                case Icon.ReportMagnify:
                    result = "report_magnify.png";
                    break;
                case Icon.ReportPicture:
                    result = "report_picture.png";
                    break;
                case Icon.ReportStart:
                    result = "report_start.png";
                    break;
                case Icon.ReportStop:
                    result = "report_stop.png";
                    break;
                case Icon.ReportUser:
                    result = "report_user.png";
                    break;
                case Icon.ReportWord:
                    result = "report_word.png";
                    break;
                case Icon.ResultsetFirst:
                    result = "resultset_first.png";
                    break;
                case Icon.ResultsetLast:
                    result = "resultset_last.png";
                    break;
                case Icon.ResultsetNext:
                    result = "resultset_next.png";
                    break;
                case Icon.ResultsetPrevious:
                    result = "resultset_previous.png";
                    break;
                case Icon.ReverseBlue:
                    result = "reverse_blue.png";
                    break;
                case Icon.ReverseGreen:
                    result = "reverse_green.png";
                    break;
                case Icon.RewindBlue:
                    result = "rewind_blue.png";
                    break;
                case Icon.RewindGreen:
                    result = "rewind_green.png";
                    break;
                case Icon.Rgb:
                    result = "rgb.png";
                    break;
                case Icon.Rosette:
                    result = "rosette.png";
                    break;
                case Icon.RosetteBlue:
                    result = "rosette_blue.png";
                    break;
                case Icon.Rss:
                    result = "rss.png";
                    break;
                case Icon.RssAdd:
                    result = "rss_add.png";
                    break;
                case Icon.RssDelete:
                    result = "rss_delete.png";
                    break;
                case Icon.RssError:
                    result = "rss_error.png";
                    break;
                case Icon.RssGo:
                    result = "rss_go.png";
                    break;
                case Icon.RssValid:
                    result = "rss_valid.png";
                    break;
                case Icon.Ruby:
                    result = "ruby.png";
                    break;
                case Icon.RubyAdd:
                    result = "ruby_add.png";
                    break;
                case Icon.RubyDelete:
                    result = "ruby_delete.png";
                    break;
                case Icon.RubyGear:
                    result = "ruby_gear.png";
                    break;
                case Icon.RubyGet:
                    result = "ruby_get.png";
                    break;
                case Icon.RubyGo:
                    result = "ruby_go.png";
                    break;
                case Icon.RubyKey:
                    result = "ruby_key.png";
                    break;
                case Icon.RubyLink:
                    result = "ruby_link.png";
                    break;
                case Icon.RubyPut:
                    result = "ruby_put.png";
                    break;
                case Icon.Script:
                    result = "script.png";
                    break;
                case Icon.ScriptAdd:
                    result = "script_add.png";
                    break;
                case Icon.ScriptCode:
                    result = "script_code.png";
                    break;
                case Icon.ScriptCodeOriginal:
                    result = "script_code_original.png";
                    break;
                case Icon.ScriptCodeRed:
                    result = "script_code_red.png";
                    break;
                case Icon.ScriptDelete:
                    result = "script_delete.png";
                    break;
                case Icon.ScriptEdit:
                    result = "script_edit.png";
                    break;
                case Icon.ScriptError:
                    result = "script_error.png";
                    break;
                case Icon.ScriptGear:
                    result = "script_gear.png";
                    break;
                case Icon.ScriptGo:
                    result = "script_go.png";
                    break;
                case Icon.ScriptKey:
                    result = "script_key.png";
                    break;
                case Icon.ScriptLightning:
                    result = "script_lightning.png";
                    break;
                case Icon.ScriptLink:
                    result = "script_link.png";
                    break;
                case Icon.ScriptPalette:
                    result = "script_palette.png";
                    break;
                case Icon.ScriptSave:
                    result = "script_save.png";
                    break;
                case Icon.ScriptStart:
                    result = "script_start.png";
                    break;
                case Icon.ScriptStop:
                    result = "script_stop.png";
                    break;
                case Icon.Seasons:
                    result = "seasons.png";
                    break;
                case Icon.SectionCollapsed:
                    result = "section_collapsed.png";
                    break;
                case Icon.SectionExpanded:
                    result = "section_expanded.png";
                    break;
                case Icon.Server:
                    result = "server.png";
                    break;
                case Icon.ServerAdd:
                    result = "server_add.png";
                    break;
                case Icon.ServerChart:
                    result = "server_chart.png";
                    break;
                case Icon.ServerCompressed:
                    result = "server_compressed.png";
                    break;
                case Icon.ServerConnect:
                    result = "server_connect.png";
                    break;
                case Icon.ServerDatabase:
                    result = "server_database.png";
                    break;
                case Icon.ServerDelete:
                    result = "server_delete.png";
                    break;
                case Icon.ServerEdit:
                    result = "server_edit.png";
                    break;
                case Icon.ServerError:
                    result = "server_error.png";
                    break;
                case Icon.ServerGo:
                    result = "server_go.png";
                    break;
                case Icon.ServerKey:
                    result = "server_key.png";
                    break;
                case Icon.ServerLightning:
                    result = "server_lightning.png";
                    break;
                case Icon.ServerLink:
                    result = "server_link.png";
                    break;
                case Icon.ServerStart:
                    result = "server_start.png";
                    break;
                case Icon.ServerStop:
                    result = "server_stop.png";
                    break;
                case Icon.ServerUncompressed:
                    result = "server_uncompressed.png";
                    break;
                case Icon.ServerWrench:
                    result = "server_wrench.png";
                    break;
                case Icon.Shading:
                    result = "shading.png";
                    break;
                case Icon.ShapesMany:
                    result = "shapes_many.png";
                    break;
                case Icon.ShapesManySelect:
                    result = "shapes_many_select.png";
                    break;
                case Icon.Shape3d:
                    result = "shape_3d.png";
                    break;
                case Icon.ShapeAlignBottom:
                    result = "shape_align_bottom.png";
                    break;
                case Icon.ShapeAlignCenter:
                    result = "shape_align_center.png";
                    break;
                case Icon.ShapeAlignLeft:
                    result = "shape_align_left.png";
                    break;
                case Icon.ShapeAlignMiddle:
                    result = "shape_align_middle.png";
                    break;
                case Icon.ShapeAlignRight:
                    result = "shape_align_right.png";
                    break;
                case Icon.ShapeAlignTop:
                    result = "shape_align_top.png";
                    break;
                case Icon.ShapeFlipHorizontal:
                    result = "shape_flip_horizontal.png";
                    break;
                case Icon.ShapeFlipVertical:
                    result = "shape_flip_vertical.png";
                    break;
                case Icon.ShapeGroup:
                    result = "shape_group.png";
                    break;
                case Icon.ShapeHandles:
                    result = "shape_handles.png";
                    break;
                case Icon.ShapeMoveBack:
                    result = "shape_move_back.png";
                    break;
                case Icon.ShapeMoveBackwards:
                    result = "shape_move_backwards.png";
                    break;
                case Icon.ShapeMoveForwards:
                    result = "shape_move_forwards.png";
                    break;
                case Icon.ShapeMoveFront:
                    result = "shape_move_front.png";
                    break;
                case Icon.ShapeRotateAnticlockwise:
                    result = "shape_rotate_anticlockwise.png";
                    break;
                case Icon.ShapeRotateClockwise:
                    result = "shape_rotate_clockwise.png";
                    break;
                case Icon.ShapeShadeA:
                    result = "shape_shade_a.png";
                    break;
                case Icon.ShapeShadeB:
                    result = "shape_shade_b.png";
                    break;
                case Icon.ShapeShadeC:
                    result = "shape_shade_c.png";
                    break;
                case Icon.ShapeShadow:
                    result = "shape_shadow.png";
                    break;
                case Icon.ShapeShadowToggle:
                    result = "shape_shadow_toggle.png";
                    break;
                case Icon.ShapeSquare:
                    result = "shape_square.png";
                    break;
                case Icon.ShapeSquareAdd:
                    result = "shape_square_add.png";
                    break;
                case Icon.ShapeSquareDelete:
                    result = "shape_square_delete.png";
                    break;
                case Icon.ShapeSquareEdit:
                    result = "shape_square_edit.png";
                    break;
                case Icon.ShapeSquareError:
                    result = "shape_square_error.png";
                    break;
                case Icon.ShapeSquareGo:
                    result = "shape_square_go.png";
                    break;
                case Icon.ShapeSquareKey:
                    result = "shape_square_key.png";
                    break;
                case Icon.ShapeSquareLink:
                    result = "shape_square_link.png";
                    break;
                case Icon.ShapeSquareSelect:
                    result = "shape_square_select.png";
                    break;
                case Icon.ShapeUngroup:
                    result = "shape_ungroup.png";
                    break;
                case Icon.Share:
                    result = "share.png";
                    break;
                case Icon.Shield:
                    result = "shield.png";
                    break;
                case Icon.ShieldAdd:
                    result = "shield_add.png";
                    break;
                case Icon.ShieldDelete:
                    result = "shield_delete.png";
                    break;
                case Icon.ShieldError:
                    result = "shield_error.png";
                    break;
                case Icon.ShieldGo:
                    result = "shield_go.png";
                    break;
                case Icon.ShieldRainbow:
                    result = "shield_rainbow.png";
                    break;
                case Icon.ShieldSilver:
                    result = "shield_silver.png";
                    break;
                case Icon.ShieldStart:
                    result = "shield_start.png";
                    break;
                case Icon.ShieldStop:
                    result = "shield_stop.png";
                    break;
                case Icon.Sitemap:
                    result = "sitemap.png";
                    break;
                case Icon.SitemapColor:
                    result = "sitemap_color.png";
                    break;
                case Icon.Smartphone:
                    result = "smartphone.png";
                    break;
                case Icon.SmartphoneAdd:
                    result = "smartphone_add.png";
                    break;
                case Icon.SmartphoneConnect:
                    result = "smartphone_connect.png";
                    break;
                case Icon.SmartphoneDelete:
                    result = "smartphone_delete.png";
                    break;
                case Icon.SmartphoneDisk:
                    result = "smartphone_disk.png";
                    break;
                case Icon.SmartphoneEdit:
                    result = "smartphone_edit.png";
                    break;
                case Icon.SmartphoneError:
                    result = "smartphone_error.png";
                    break;
                case Icon.SmartphoneGo:
                    result = "smartphone_go.png";
                    break;
                case Icon.SmartphoneKey:
                    result = "smartphone_key.png";
                    break;
                case Icon.SmartphoneWrench:
                    result = "smartphone_wrench.png";
                    break;
                case Icon.SortAscending:
                    result = "sort_ascending.png";
                    break;
                case Icon.SortDescending:
                    result = "sort_descending.png";
                    break;
                case Icon.Sound:
                    result = "sound.png";
                    break;
                case Icon.SoundAdd:
                    result = "sound_add.png";
                    break;
                case Icon.SoundDelete:
                    result = "sound_delete.png";
                    break;
                case Icon.SoundHigh:
                    result = "sound_high.png";
                    break;
                case Icon.SoundIn:
                    result = "sound_in.png";
                    break;
                case Icon.SoundLow:
                    result = "sound_low.png";
                    break;
                case Icon.SoundMute:
                    result = "sound_mute.png";
                    break;
                case Icon.SoundNone:
                    result = "sound_none.png";
                    break;
                case Icon.SoundOut:
                    result = "sound_out.png";
                    break;
                case Icon.Spellcheck:
                    result = "spellcheck.png";
                    break;
                case Icon.Sport8ball:
                    result = "sport_8ball.png";
                    break;
                case Icon.SportBasketball:
                    result = "sport_basketball.png";
                    break;
                case Icon.SportFootball:
                    result = "sport_football.png";
                    break;
                case Icon.SportGolf:
                    result = "sport_golf.png";
                    break;
                case Icon.SportGolfPractice:
                    result = "sport_golf_practice.png";
                    break;
                case Icon.SportRaquet:
                    result = "sport_raquet.png";
                    break;
                case Icon.SportShuttlecock:
                    result = "sport_shuttlecock.png";
                    break;
                case Icon.SportSoccer:
                    result = "sport_soccer.png";
                    break;
                case Icon.SportTennis:
                    result = "sport_tennis.png";
                    break;
                case Icon.Star:
                    result = "star.png";
                    break;
                case Icon.StarBronze:
                    result = "star_bronze.png";
                    break;
                case Icon.StarBronzeHalfGrey:
                    result = "star_bronze_half_grey.png";
                    break;
                case Icon.StarGold:
                    result = "star_gold.png";
                    break;
                case Icon.StarGoldHalfGrey:
                    result = "star_gold_half_grey.png";
                    break;
                case Icon.StarGoldHalfSilver:
                    result = "star_gold_half_silver.png";
                    break;
                case Icon.StarGrey:
                    result = "star_grey.png";
                    break;
                case Icon.StarHalfGrey:
                    result = "star_half_grey.png";
                    break;
                case Icon.StarSilver:
                    result = "star_silver.png";
                    break;
                case Icon.StatusAway:
                    result = "status_away.png";
                    break;
                case Icon.StatusBeRightBack:
                    result = "status_be_right_back.png";
                    break;
                case Icon.StatusBusy:
                    result = "status_busy.png";
                    break;
                case Icon.StatusInvisible:
                    result = "status_invisible.png";
                    break;
                case Icon.StatusOffline:
                    result = "status_offline.png";
                    break;
                case Icon.StatusOnline:
                    result = "status_online.png";
                    break;
                case Icon.Stop:
                    result = "stop.png";
                    break;
                case Icon.StopBlue:
                    result = "stop_blue.png";
                    break;
                case Icon.StopGreen:
                    result = "stop_green.png";
                    break;
                case Icon.StopRed:
                    result = "stop_red.png";
                    break;
                case Icon.Style:
                    result = "style.png";
                    break;
                case Icon.StyleAdd:
                    result = "style_add.png";
                    break;
                case Icon.StyleDelete:
                    result = "style_delete.png";
                    break;
                case Icon.StyleEdit:
                    result = "style_edit.png";
                    break;
                case Icon.StyleGo:
                    result = "style_go.png";
                    break;
                case Icon.Sum:
                    result = "sum.png";
                    break;
                case Icon.Tab:
                    result = "tab.png";
                    break;
                case Icon.Table:
                    result = "table.png";
                    break;
                case Icon.TableAdd:
                    result = "table_add.png";
                    break;
                case Icon.TableCell:
                    result = "table_cell.png";
                    break;
                case Icon.TableColumn:
                    result = "table_column.png";
                    break;
                case Icon.TableColumnAdd:
                    result = "table_column_add.png";
                    break;
                case Icon.TableColumnDelete:
                    result = "table_column_delete.png";
                    break;
                case Icon.TableConnect:
                    result = "table_connect.png";
                    break;
                case Icon.TableDelete:
                    result = "table_delete.png";
                    break;
                case Icon.TableEdit:
                    result = "table_edit.png";
                    break;
                case Icon.TableError:
                    result = "table_error.png";
                    break;
                case Icon.TableGear:
                    result = "table_gear.png";
                    break;
                case Icon.TableGo:
                    result = "table_go.png";
                    break;
                case Icon.TableKey:
                    result = "table_key.png";
                    break;
                case Icon.TableLightning:
                    result = "table_lightning.png";
                    break;
                case Icon.TableLink:
                    result = "table_link.png";
                    break;
                case Icon.TableMultiple:
                    result = "table_multiple.png";
                    break;
                case Icon.TableRefresh:
                    result = "table_refresh.png";
                    break;
                case Icon.TableRelationship:
                    result = "table_relationship.png";
                    break;
                case Icon.TableRow:
                    result = "table_row.png";
                    break;
                case Icon.TableRowDelete:
                    result = "table_row_delete.png";
                    break;
                case Icon.TableRowInsert:
                    result = "table_row_insert.png";
                    break;
                case Icon.TableSave:
                    result = "table_save.png";
                    break;
                case Icon.TableSort:
                    result = "table_sort.png";
                    break;
                case Icon.TabAdd:
                    result = "tab_add.png";
                    break;
                case Icon.TabBlue:
                    result = "tab_blue.png";
                    break;
                case Icon.TabDelete:
                    result = "tab_delete.png";
                    break;
                case Icon.TabEdit:
                    result = "tab_edit.png";
                    break;
                case Icon.TabGo:
                    result = "tab_go.png";
                    break;
                case Icon.TabGreen:
                    result = "tab_green.png";
                    break;
                case Icon.TabRed:
                    result = "tab_red.png";
                    break;
                case Icon.Tag:
                    result = "tag.png";
                    break;
                case Icon.TagsGrey:
                    result = "tags_grey.png";
                    break;
                case Icon.TagsRed:
                    result = "tags_red.png";
                    break;
                case Icon.TagBlue:
                    result = "tag_blue.png";
                    break;
                case Icon.TagBlueAdd:
                    result = "tag_blue_add.png";
                    break;
                case Icon.TagBlueDelete:
                    result = "tag_blue_delete.png";
                    break;
                case Icon.TagBlueEdit:
                    result = "tag_blue_edit.png";
                    break;
                case Icon.TagGreen:
                    result = "tag_green.png";
                    break;
                case Icon.TagOrange:
                    result = "tag_orange.png";
                    break;
                case Icon.TagPink:
                    result = "tag_pink.png";
                    break;
                case Icon.TagPurple:
                    result = "tag_purple.png";
                    break;
                case Icon.TagRed:
                    result = "tag_red.png";
                    break;
                case Icon.TagYellow:
                    result = "tag_yellow.png";
                    break;
                case Icon.Telephone:
                    result = "telephone.png";
                    break;
                case Icon.TelephoneAdd:
                    result = "telephone_add.png";
                    break;
                case Icon.TelephoneDelete:
                    result = "telephone_delete.png";
                    break;
                case Icon.TelephoneEdit:
                    result = "telephone_edit.png";
                    break;
                case Icon.TelephoneError:
                    result = "telephone_error.png";
                    break;
                case Icon.TelephoneGo:
                    result = "telephone_go.png";
                    break;
                case Icon.TelephoneKey:
                    result = "telephone_key.png";
                    break;
                case Icon.TelephoneLink:
                    result = "telephone_link.png";
                    break;
                case Icon.TelephoneRed:
                    result = "telephone_red.png";
                    break;
                case Icon.Television:
                    result = "television.png";
                    break;
                case Icon.TelevisionAdd:
                    result = "television_add.png";
                    break;
                case Icon.TelevisionDelete:
                    result = "television_delete.png";
                    break;
                case Icon.TelevisionIn:
                    result = "television_in.png";
                    break;
                case Icon.TelevisionOff:
                    result = "television_off.png";
                    break;
                case Icon.TelevisionOut:
                    result = "television_out.png";
                    break;
                case Icon.TelevisionStar:
                    result = "television_star.png";
                    break;
                case Icon.Textfield:
                    result = "textfield.png";
                    break;
                case Icon.TextfieldAdd:
                    result = "textfield_add.png";
                    break;
                case Icon.TextfieldDelete:
                    result = "textfield_delete.png";
                    break;
                case Icon.TextfieldKey:
                    result = "textfield_key.png";
                    break;
                case Icon.TextfieldRename:
                    result = "textfield_rename.png";
                    break;
                case Icon.TextAb:
                    result = "text_ab.png";
                    break;
                case Icon.TextAlignCenter:
                    result = "text_align_center.png";
                    break;
                case Icon.TextAlignJustify:
                    result = "text_align_justify.png";
                    break;
                case Icon.TextAlignLeft:
                    result = "text_align_left.png";
                    break;
                case Icon.TextAlignRight:
                    result = "text_align_right.png";
                    break;
                case Icon.TextAllcaps:
                    result = "text_allcaps.png";
                    break;
                case Icon.TextBold:
                    result = "text_bold.png";
                    break;
                case Icon.TextColumns:
                    result = "text_columns.png";
                    break;
                case Icon.TextComplete:
                    result = "text_complete.png";
                    break;
                case Icon.TextDirection:
                    result = "text_direction.png";
                    break;
                case Icon.TextDoubleUnderline:
                    result = "text_double_underline.png";
                    break;
                case Icon.TextDropcaps:
                    result = "text_dropcaps.png";
                    break;
                case Icon.TextFit:
                    result = "text_fit.png";
                    break;
                case Icon.TextFlip:
                    result = "text_flip.png";
                    break;
                case Icon.TextFontDefault:
                    result = "text_font_default.png";
                    break;
                case Icon.TextHeading1:
                    result = "text_heading_1.png";
                    break;
                case Icon.TextHeading2:
                    result = "text_heading_2.png";
                    break;
                case Icon.TextHeading3:
                    result = "text_heading_3.png";
                    break;
                case Icon.TextHeading4:
                    result = "text_heading_4.png";
                    break;
                case Icon.TextHeading5:
                    result = "text_heading_5.png";
                    break;
                case Icon.TextHeading6:
                    result = "text_heading_6.png";
                    break;
                case Icon.TextHorizontalrule:
                    result = "text_horizontalrule.png";
                    break;
                case Icon.TextIndent:
                    result = "text_indent.png";
                    break;
                case Icon.TextIndentRemove:
                    result = "text_indent_remove.png";
                    break;
                case Icon.TextInverse:
                    result = "text_inverse.png";
                    break;
                case Icon.TextItalic:
                    result = "text_italic.png";
                    break;
                case Icon.TextKerning:
                    result = "text_kerning.png";
                    break;
                case Icon.TextLeftToRight:
                    result = "text_left_to_right.png";
                    break;
                case Icon.TextLetterspacing:
                    result = "text_letterspacing.png";
                    break;
                case Icon.TextLetterOmega:
                    result = "text_letter_omega.png";
                    break;
                case Icon.TextLinespacing:
                    result = "text_linespacing.png";
                    break;
                case Icon.TextListBullets:
                    result = "text_list_bullets.png";
                    break;
                case Icon.TextListNumbers:
                    result = "text_list_numbers.png";
                    break;
                case Icon.TextLowercase:
                    result = "text_lowercase.png";
                    break;
                case Icon.TextLowercaseA:
                    result = "text_lowercase_a.png";
                    break;
                case Icon.TextMirror:
                    result = "text_mirror.png";
                    break;
                case Icon.TextPaddingBottom:
                    result = "text_padding_bottom.png";
                    break;
                case Icon.TextPaddingLeft:
                    result = "text_padding_left.png";
                    break;
                case Icon.TextPaddingRight:
                    result = "text_padding_right.png";
                    break;
                case Icon.TextPaddingTop:
                    result = "text_padding_top.png";
                    break;
                case Icon.TextReplace:
                    result = "text_replace.png";
                    break;
                case Icon.TextRightToLeft:
                    result = "text_right_to_left.png";
                    break;
                case Icon.TextRotate0:
                    result = "text_rotate_0.png";
                    break;
                case Icon.TextRotate180:
                    result = "text_rotate_180.png";
                    break;
                case Icon.TextRotate270:
                    result = "text_rotate_270.png";
                    break;
                case Icon.TextRotate90:
                    result = "text_rotate_90.png";
                    break;
                case Icon.TextRuler:
                    result = "text_ruler.png";
                    break;
                case Icon.TextShading:
                    result = "text_shading.png";
                    break;
                case Icon.TextSignature:
                    result = "text_signature.png";
                    break;
                case Icon.TextSmallcaps:
                    result = "text_smallcaps.png";
                    break;
                case Icon.TextSpelling:
                    result = "text_spelling.png";
                    break;
                case Icon.TextStrikethrough:
                    result = "text_strikethrough.png";
                    break;
                case Icon.TextSubscript:
                    result = "text_subscript.png";
                    break;
                case Icon.TextSuperscript:
                    result = "text_superscript.png";
                    break;
                case Icon.TextTab:
                    result = "text_tab.png";
                    break;
                case Icon.TextUnderline:
                    result = "text_underline.png";
                    break;
                case Icon.TextUppercase:
                    result = "text_uppercase.png";
                    break;
                case Icon.Theme:
                    result = "theme.png";
                    break;
                case Icon.ThumbDown:
                    result = "thumb_down.png";
                    break;
                case Icon.ThumbUp:
                    result = "thumb_up.png";
                    break;
                case Icon.Tick:
                    result = "tick.png";
                    break;
                case Icon.Time:
                    result = "time.png";
                    break;
                case Icon.TimelineMarker:
                    result = "timeline_marker.png";
                    break;
                case Icon.TimeAdd:
                    result = "time_add.png";
                    break;
                case Icon.TimeDelete:
                    result = "time_delete.png";
                    break;
                case Icon.TimeGo:
                    result = "time_go.png";
                    break;
                case Icon.TimeGreen:
                    result = "time_green.png";
                    break;
                case Icon.TimeRed:
                    result = "time_red.png";
                    break;
                case Icon.Transmit:
                    result = "transmit.png";
                    break;
                case Icon.TransmitAdd:
                    result = "transmit_add.png";
                    break;
                case Icon.TransmitBlue:
                    result = "transmit_blue.png";
                    break;
                case Icon.TransmitDelete:
                    result = "transmit_delete.png";
                    break;
                case Icon.TransmitEdit:
                    result = "transmit_edit.png";
                    break;
                case Icon.TransmitError:
                    result = "transmit_error.png";
                    break;
                case Icon.TransmitGo:
                    result = "transmit_go.png";
                    break;
                case Icon.TransmitRed:
                    result = "transmit_red.png";
                    break;
                case Icon.Tux:
                    result = "tux.png";
                    break;
                case Icon.User:
                    result = "user.png";
                    break;
                case Icon.UserAdd:
                    result = "user_add.png";
                    break;
                case Icon.UserAlert:
                    result = "user_alert.png";
                    break;
                case Icon.UserB:
                    result = "user_b.png";
                    break;
                case Icon.UserBrown:
                    result = "user_brown.png";
                    break;
                case Icon.UserComment:
                    result = "user_comment.png";
                    break;
                case Icon.UserCross:
                    result = "user_cross.png";
                    break;
                case Icon.UserDelete:
                    result = "user_delete.png";
                    break;
                case Icon.UserEarth:
                    result = "user_earth.png";
                    break;
                case Icon.UserEdit:
                    result = "user_edit.png";
                    break;
                case Icon.UserFemale:
                    result = "user_female.png";
                    break;
                case Icon.UserGo:
                    result = "user_go.png";
                    break;
                case Icon.UserGray:
                    result = "user_gray.png";
                    break;
                case Icon.UserGrayCool:
                    result = "user_gray_cool.png";
                    break;
                case Icon.UserGreen:
                    result = "user_green.png";
                    break;
                case Icon.UserHome:
                    result = "user_home.png";
                    break;
                case Icon.UserKey:
                    result = "user_key.png";
                    break;
                case Icon.UserMagnify:
                    result = "user_magnify.png";
                    break;
                case Icon.UserMature:
                    result = "user_mature.png";
                    break;
                case Icon.UserOrange:
                    result = "user_orange.png";
                    break;
                case Icon.UserRed:
                    result = "user_red.png";
                    break;
                case Icon.UserStar:
                    result = "user_star.png";
                    break;
                case Icon.UserSuit:
                    result = "user_suit.png";
                    break;
                case Icon.UserSuitBlack:
                    result = "user_suit_black.png";
                    break;
                case Icon.UserTick:
                    result = "user_tick.png";
                    break;
                case Icon.Vcard:
                    result = "vcard.png";
                    break;
                case Icon.VcardAdd:
                    result = "vcard_add.png";
                    break;
                case Icon.VcardDelete:
                    result = "vcard_delete.png";
                    break;
                case Icon.VcardEdit:
                    result = "vcard_edit.png";
                    break;
                case Icon.VcardKey:
                    result = "vcard_key.png";
                    break;
                case Icon.Vector:
                    result = "vector.png";
                    break;
                case Icon.VectorAdd:
                    result = "vector_add.png";
                    break;
                case Icon.VectorDelete:
                    result = "vector_delete.png";
                    break;
                case Icon.VectorKey:
                    result = "vector_key.png";
                    break;
                case Icon.Wand:
                    result = "wand.png";
                    break;
                case Icon.WeatherCloud:
                    result = "weather_cloud.png";
                    break;
                case Icon.WeatherClouds:
                    result = "weather_clouds.png";
                    break;
                case Icon.WeatherCloudy:
                    result = "weather_cloudy.png";
                    break;
                case Icon.WeatherCloudyRain:
                    result = "weather_cloudy_rain.png";
                    break;
                case Icon.WeatherLightning:
                    result = "weather_lightning.png";
                    break;
                case Icon.WeatherRain:
                    result = "weather_rain.png";
                    break;
                case Icon.WeatherSnow:
                    result = "weather_snow.png";
                    break;
                case Icon.WeatherSun:
                    result = "weather_sun.png";
                    break;
                case Icon.Webcam:
                    result = "webcam.png";
                    break;
                case Icon.WebcamAdd:
                    result = "webcam_add.png";
                    break;
                case Icon.WebcamConnect:
                    result = "webcam_connect.png";
                    break;
                case Icon.WebcamDelete:
                    result = "webcam_delete.png";
                    break;
                case Icon.WebcamError:
                    result = "webcam_error.png";
                    break;
                case Icon.WebcamStart:
                    result = "webcam_start.png";
                    break;
                case Icon.WebcamStop:
                    result = "webcam_stop.png";
                    break;
                case Icon.World:
                    result = "world.png";
                    break;
                case Icon.WorldAdd:
                    result = "world_add.png";
                    break;
                case Icon.WorldConnect:
                    result = "world_connect.png";
                    break;
                case Icon.WorldDawn:
                    result = "world_dawn.png";
                    break;
                case Icon.WorldDelete:
                    result = "world_delete.png";
                    break;
                case Icon.WorldEdit:
                    result = "world_edit.png";
                    break;
                case Icon.WorldGo:
                    result = "world_go.png";
                    break;
                case Icon.WorldKey:
                    result = "world_key.png";
                    break;
                case Icon.WorldLink:
                    result = "world_link.png";
                    break;
                case Icon.WorldNight:
                    result = "world_night.png";
                    break;
                case Icon.WorldOrbit:
                    result = "world_orbit.png";
                    break;
                case Icon.Wrench:
                    result = "wrench.png";
                    break;
                case Icon.WrenchOrange:
                    result = "wrench_orange.png";
                    break;
                case Icon.Xhtml:
                    result = "xhtml.png";
                    break;
                case Icon.XhtmlAdd:
                    result = "xhtml_add.png";
                    break;
                case Icon.XhtmlDelete:
                    result = "xhtml_delete.png";
                    break;
                case Icon.XhtmlError:
                    result = "xhtml_error.png";
                    break;
                case Icon.XhtmlGo:
                    result = "xhtml_go.png";
                    break;
                case Icon.XhtmlValid:
                    result = "xhtml_valid.png";
                    break;
                case Icon.Zoom:
                    result = "zoom.png";
                    break;
                case Icon.ZoomIn:
                    result = "zoom_in.png";
                    break;
                case Icon.ZoomOut:
                    result = "zoom_out.png";
                    break;
                case Icon.SystemClose:
                    result = "system_close.gif";
                    break;
                case Icon.SystemNew:
                    result = "system_new.gif";
                    break;
                case Icon.SystemSave:
                    result = "system_save.gif";
                    break;
                case Icon.SystemSaveClose:
                    result = "system_saveclose.gif";
                    break;
                case Icon.SystemSaveNew:
                    result = "system_savenew.gif";
                    break;
                case Icon.SystemSearch:
                    result = "system_search.gif";
                    break;
            }

            return result;
        }
    }
}