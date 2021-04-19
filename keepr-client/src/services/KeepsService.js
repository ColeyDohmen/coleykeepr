import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    try {
      const res = await api.get('api/keeps')
      logger.log(res)
      AppState.keeps = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async getKeep(id) {
    try {
      const res = await api.get('api/keeps/' + id)
      logger.log(res)
      AppState.activeKeep = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async createKeep(keep) {
    await api.post('api/keeps', keep)
    this.getKeeps()
  }
}

export const keepsService = new KeepsService()