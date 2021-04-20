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
    const res = await api.post('api/vaults', vault)
    AppState.vaults.push(res.data)
    return res.data.id
    // this.getVaults()
  }

  async deleteVault(id) {
    await api.delete(`api/vaults/${id}`)
  }

  async getAllKeepsByVaultId(id) {
    try {
      const res = await api.get(`api/vaults/${id}/keeps`)
      AppState.keeps = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    logger.log(res)
    AppState.vaults = res.data
  }
}

export const vaultsService = new VaultsService()
