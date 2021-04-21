import Swal from 'sweetalert2'
import { logger } from '../utils/Logger'

export default class NotificationService {
  static async confirmAction(title = 'Are you sure?', text = "You won't be able to revert this!") {
    try {
      const res = await Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
      })
      logger.log(res)
      if (res.isConfirmed) {
        Swal.fire(
          'Delete!',
          'Your file has been deleted.',
          'success'
        )
        return true
      }
      return false
    } catch (error) {
      logger.error(error)
    }
  }

  static toast(title = 'Default Toasty', display = 'warning') {
    // @ts-ignore
    Swal.fire({
      title: title,
      icon: display,
      position: 'top-right',
      timer: 3000,
      toast: true,
      showConfirmButton: false,
      iconHtml: '<img src="https://media.giphy.com/media/sBQ1lBvDLz476/giphy.gif" style="width:50px; border-radius: 50%">'
    })
  }
}
