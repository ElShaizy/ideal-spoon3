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
			name: 'F_COUNTRY',
			area: 'COUNTRY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_country',
				updateFilesTickets: 'UpdateFilesTicketsF_country',
				setFile: 'SetFileF_country'
			}
		})

		/** The primary key. */
		this.ValCodcountry_pk = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcountry_pk',
			originId: 'ValCodcountry_pk',
			area: 'COUNTRY',
			field: 'CODCOUNTRY_PK',
			description: '',
		}).cloneFrom(values?.ValCodcountry_pk))
		this.stopWatchers.push(watch(() => this.ValCodcountry_pk.value, (newValue, oldValue) => this.onUpdate('country.codcountry_pk', this.ValCodcountry_pk, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValCountry = reactive(new modelFieldType.String({
			id: 'ValCountry',
			originId: 'ValCountry',
			area: 'COUNTRY',
			field: 'COUNTRY',
			maxLength: 50,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.ValCountry))
		this.stopWatchers.push(watch(() => this.ValCountry.value, (newValue, oldValue) => this.onUpdate('country.country', this.ValCountry, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFCountryViewModel instance.
	 * @returns {QFormFCountryViewModel} A new instance of QFormFCountryViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcountry_pk'

	get QPrimaryKey() { return this.ValCodcountry_pk.value }
	set QPrimaryKey(value) { this.ValCodcountry_pk.updateValue(value) }
}
