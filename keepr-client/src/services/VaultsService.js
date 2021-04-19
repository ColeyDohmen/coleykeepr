import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  async getVaults() {
    try {
      const res = await api.get('api/vaults')
      logger.log(res)
      AppState.vaults = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async getVault(id) {
    try {
      const res = await api.get('api/vaults/' + id)
      logger.log(res)
      AppState.activeVault = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async createVault(vault) {
    await api.post('api/vaults', vault)
    this.getVaults()
  }
}

export const vaultsService = new VaultsService()
