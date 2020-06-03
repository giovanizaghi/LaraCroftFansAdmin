function toggleSubmenu(menu){
    try{        
        var submenu = menu.nextElementSibling
        $(submenu).toggle('blind')
    }
    catch(Exception){
        swal('Oops...', Exception.message, 'error')
    }
    
}
