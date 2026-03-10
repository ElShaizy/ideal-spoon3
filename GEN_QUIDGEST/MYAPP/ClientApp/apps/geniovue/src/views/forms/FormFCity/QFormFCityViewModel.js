/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'F_CITY',
			area: 'CITY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_city',
				updateFilesTickets: 'UpdateFilesTicketsF_city',
				setFile: 'SetFileF_city'
			}
		})

		/** The primary key. */
		this.ValCodcity = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcity',
			originId: 'ValCodcity',
			area: 'CITY',
			field: 'CODCITY',
			description: computed(() => this.Resources.CITY35974),
		}).cloneFrom(values?.ValCodcity))
		this.stopWatchers.push(watch(() => this.ValCodcity.value, (newValue, oldValue) => this.onUpdate('city.codcity', this.ValCodcity, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodcountry_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcountry_fk',
			originId: 'ValCodcountry_fk',
			area: 'CITY',
			field: 'CODCOUNTRY_FK',
			relatedArea: 'COUNTRY',
			description: computed(() => this.Resources.COUNTRY45120),
		}).cloneFrom(values?.ValCodcountry_fk))
		this.stopWatchers.push(watch(() => this.ValCodcountry_fk.value, (newValue, oldValue) => this.onUpdate('city.codcountry_fk', this.ValCodcountry_fk, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCity = reactive(new modelFieldType.String({
			id: 'ValCity',
			originId: 'ValCity',
			area: 'CITY',
			field: 'CITY',
			maxLength: 50,
			description: computed(() => this.Resources.CITY42505),
		}).cloneFrom(values?.ValCity))
		this.stopWatchers.push(watch(() => this.ValCity.value, (newValue, oldValue) => this.onUpdate('city.city', this.ValCity, newValue, oldValue)))

		this.TableCountryCountry = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCountryCountry',
			originId: 'ValCountry',
			area: 'COUNTRY',
			field: 'COUNTRY',
			maxLength: 50,
			description: computed(() => this.Resources.COUNTRY64133),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCountryCountry))
		this.stopWatchers.push(watch(() => this.TableCountryCountry.value, (newValue, oldValue) => this.onUpdate('country.country', this.TableCountryCountry, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFCityViewModel instance.
	 * @returns {QFormFCityViewModel} A new instance of QFormFCityViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcity'

	get QPrimaryKey() { return this.ValCodcity.value }
	set QPrimaryKey(value) { this.ValCodcity.updateValue(value) }
}
